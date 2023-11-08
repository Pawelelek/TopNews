using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Walter.Core.DTO_s.Post;
using Walter.Core.Interfaces;
using Walter.Web.Models;
using X.PagedList;

namespace Walter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IPostService postService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _postService = postService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync(int? page)
        {
            List<PostDto> posts = await _postService.GetAll();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowCurrentPost(int id)
        {
            var postDto = await _postService.Get(id);

            if (postDto == null)
            {
                ViewBag.AuthError = "Post not found.";
                return View();
            }
            return View(postDto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PostsByCategory(int id)
        {
            List<PostDto> posts = await _postService.GetByCategory(id);
            int pageSize = 20;
            int pageNumber = 1;
            return View("Index", posts.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([FromForm] string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction("Index");
            }
            List<PostDto> posts = await _postService.Search(searchString);
            int pageSize = 20;
            int pageNumber = 1;
            return View("Index", posts.ToPagedList(pageNumber, pageSize));
        }

        [Route("Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404: return View("NotFound");
                    break;
                default:
                    return View("Error");
            }
        }
    }
}
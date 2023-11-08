using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Entities.Site;
using Walter.Core.Interfaces;

namespace Walter.Core.Services
{
    public class DashboardAccessService : IDashboardAccessService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<IpAddress> _dashboardAccessRepo;



        public DashboardAccessService(IMapper mapper, IRepository<IpAddress> dashboardAccessRepo)
        {
            _mapper = mapper;
            _dashboardAccessRepo = dashboardAccessRepo;
        }



        public async Task Create(IpAddress model)
        {
            await _dashboardAccessRepo.Insert(_mapper.Map<IpAddress>(model));
            await _dashboardAccessRepo.Save();
        }



        public async Task Delete(int id)
        {
            var categoryDto = await Get(id);
            if (categoryDto == null) return;



            await _dashboardAccessRepo.Delete(id);
            await _dashboardAccessRepo.Save();
        }



        public async Task<IpAddress?> Get(int id)
        {
            if (id < 0) return null;
            var category = await _dashboardAccessRepo.GetByID(id);



            if (category == null) return null;
            return _mapper.Map<IpAddress>(category);
        }



        public async Task<List<IpAddress>> GetAll()
        {
            var result = await _dashboardAccessRepo.GetAll();
            return _mapper.Map<List<IpAddress>>(result);
        }



        public async Task Update(IpAddress model)
        {
            await _dashboardAccessRepo.Update(_mapper.Map<IpAddress>(model));
            await _dashboardAccessRepo.Save();
        }
    }
}

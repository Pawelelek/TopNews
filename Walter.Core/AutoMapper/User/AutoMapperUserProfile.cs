﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.User;
using Walter.Core.Entities.User;

namespace Walter.Core.AutoMapper.User
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UsersDto, AppUser>().ReverseMap();
            CreateMap<EditUserDto, AppUser>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<CreateUserDto, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
            CreateMap<AppUser, CreateUserDto>();

        }
    }
}

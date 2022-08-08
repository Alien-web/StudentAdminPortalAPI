using AutoMapper;
using data=StudentAdminPortal.API.DataModels;
using domain=StudentAdminPortal.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Profiles.AfterMap;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<data.Students, domain.Student>().ReverseMap();
            CreateMap<data.Gender,domain.Gender>().ReverseMap();
            CreateMap<data.Address,domain.Address>().ReverseMap();
            CreateMap<domain.UpdateStudentRequest, data.Students>();
               // .AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}

using AutoMapper;
using EFCoreCodeFirstSample.Entities;
using EFCoreCodeFirstSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Attendence, AttendenceViewModel>().ReverseMap();
        }

    }
}

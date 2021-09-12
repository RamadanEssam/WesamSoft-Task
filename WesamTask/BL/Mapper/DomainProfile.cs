using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WesamTask.DAL.Entities;
using WesamTask.Models;

namespace WesamTask.BL.Mapper
{
   
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

        }
    }
}

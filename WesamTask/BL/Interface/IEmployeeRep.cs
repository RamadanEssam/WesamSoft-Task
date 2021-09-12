using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WesamTask.DAL.Entities;
using WesamTask.Models;

namespace WesamTask.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        void Add(EmployeeVM emp);
        EmployeeVM GetById(int id);

        void Edit(EmployeeVM dpt);
        void Delete(int id);
    }
}

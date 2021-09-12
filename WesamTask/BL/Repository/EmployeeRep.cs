using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WesamTask.BL.Interface;
using WesamTask.DAL.DataBase;
using WesamTask.DAL.Entities;
using WesamTask.Models;

namespace WesamTask.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer db , IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public void Add(EmployeeVM emp)
        {

            // Using Mapping By Auto Mapper
            var data = mapper.Map<Employee>(emp);

            db.Employee.Add(data);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Employee.Find(id);
            db.Employee.Remove(DeletedObject);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {

            // Using Mapping By Auto Mapper

            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            db.SaveChanges();

            
        }

        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmployee();

            return data;
        }


        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeById(id); return data;
        }


        // Refactor

        private IQueryable<EmployeeVM> GetAllEmployee()
        {
            return db.Employee
                .Select(a => new EmployeeVM { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName, Contact = a.Contact, Email = a.Email, DateOfBirth = a.DateOfBirth });
        }


        private EmployeeVM GetEmployeeById(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                     .Select(a => new EmployeeVM { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName, Contact = a.Contact, Email = a.Email, DateOfBirth = a.DateOfBirth })
                                     .FirstOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using WesamTask.BL.Interface;
using WesamTask.Models;

namespace WesamTask.Controllers
{

    public class EmployeeController : Controller
    {


        // Loosly Coupled
        private readonly IEmployeeRep Employee;
        public EmployeeController(IEmployeeRep Employee)
        {
            this.Employee = Employee;

        }
        public IActionResult Index()
        {
            var employees = Employee.Get();
            return View(employees);
        }
                public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                // support wondows only
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }
        public IActionResult Edit(int id)
        {
            var data = Employee.GetById(id);

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = Employee.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }
    }


}

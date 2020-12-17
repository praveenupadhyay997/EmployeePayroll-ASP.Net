using EmployeePayrollMVC.Models;
using EmployeePayrollMVC.Models.Common;
using EmployeePayrollMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeViewModel> list = employeeRepository.GetEmployees();
            return View(list);
        }
        // GET: Employee
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEmployee(RegisterRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = employeeRepository.RegisterEmployee(employee);
            }
            ModelState.Clear();

            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        // Controller Method to Edit the employee details
        public ActionResult Edit(Employee model)
        {
            Employee emp = employeeRepository.GetEmployee(model.EmpId);
            return View(emp);
        }
        // Controller method to update the details of an employee by getting the employee model
        public ActionResult Update(Employee model)
        {
            int data = employeeRepository.Update(model);
            if (data != 0)
                return RedirectToAction("Index");
            else
                return View("Edit");

        }
    }
}
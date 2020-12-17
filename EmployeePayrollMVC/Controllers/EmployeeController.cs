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
        public ActionResult Register(RegisterRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = employeeRepository.RegisterEmployee(employee);
            }

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
        // Controller method to delete the details of an employee from the database -- When call is passed here note that delete button is clicked
        public ActionResult Delete(Employee model)
        {
            Employee emp = employeeRepository.GetEmployee(model.EmpId);

            return View(emp);
        }
        // Controller method to delete the details of an employee from the database -- When call is passed here the view is verifying whether delete call is sure or not
        [HttpPost]
        public ActionResult DeleteEmployee(Employee model)
        {
            int result = employeeRepository.DeleteEmployee(model.EmpId);
            if (result != 0)
                return RedirectToAction("Index");
            else
                return View("Delete", result);
        }
    }
}
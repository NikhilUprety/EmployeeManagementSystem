﻿using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var employees = _employeeDbContext.EmployeeTable?.ToList();
            return View(employees);
        }
        public IActionResult Addemployee()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Addemployee(EmployeeViewModel employeeVm)
        {
            if (_employeeDbContext.EmployeeTable.Any(x => x.Email == employeeVm.Email || x.PhoneNumber == employeeVm.PhoneNumber))
            {
                TempData["ErrorMessage"] = "Email or Phone Already Exists.";
                return RedirectToAction("Addemployee");
            }
            else
            {
                var employees = new EmployeeModel()
                {
                    Name = employeeVm.Name,
                    Email = employeeVm.Email,
                    PhoneNumber = employeeVm.PhoneNumber,
                    Address = employeeVm.Address,
                    Position = employeeVm.Position
                };
                _employeeDbContext.EmployeeTable?.Add(employees);
                _employeeDbContext.SaveChanges();
                TempData["SuccessMessage"] = "Data Entered Successfully.";
                return RedirectToAction("Employees");
            }

        }
        public IActionResult Update(int id)
        {
            var employee = _employeeDbContext.EmployeeTable.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                var model = new UpdateViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address,
                    Position = employee.Position
                };
                return View(model);
            }
            TempData["ErrorMessage"] = "No Data Found";
            return RedirectToAction("Employees");
        }

        [HttpPost]
        public IActionResult Update(UpdateViewModel Updatevm)
        {
            var employee = _employeeDbContext.EmployeeTable.Find(Updatevm.Id);
            if (employee != null)
            {


                employee.Id = Updatevm.Id;
                employee.Name = Updatevm.Name;
                employee.Email = Updatevm.Email;
                employee.PhoneNumber = Updatevm.PhoneNumber;
                employee.Address = Updatevm.Address;
                employee.Position = Updatevm.Position;
                _employeeDbContext.SaveChanges();
                TempData["SuccessMessage"] = "Data saved ";
                return RedirectToAction("Employees");
            }
            TempData["ErrorMessage"] = "No DataEntry";

            return RedirectToAction("Update");

        }
        public IActionResult Delete(int id)
        {
            var employee = _employeeDbContext.EmployeeTable.Find(id);
            if (employee != null)
            {
                _employeeDbContext.EmployeeTable.Remove(employee);
                _employeeDbContext.SaveChanges();
                TempData["SuccessMessage"] = "Deleted Successfully.";
                return RedirectToAction("Employees");
            }
            TempData["ErrorMessage"] = "Not Deleted Successfully.";
            return RedirectToAction("Employees");
        }

    }
}


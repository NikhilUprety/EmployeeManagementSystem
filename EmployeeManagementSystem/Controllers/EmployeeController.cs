using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Employees() {
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
            if(_employeeDbContext.EmployeeTable.Any(x=>x.Email == employeeVm.Email || x.PhoneNumber == employeeVm.PhoneNumber)) {
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
            return View();
        }


    }
}

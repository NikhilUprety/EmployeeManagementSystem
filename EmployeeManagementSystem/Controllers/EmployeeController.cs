using Azure.Search.Documents.Models;
using EmployeeManagementSystem.DataContext;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Domain;
using EmployeeManagementSystem.Repository.Implementation;
using EmployeeManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        //Dependency injection
        private readonly IEmployeeRepository _employeerepo;
        public EmployeeController(IEmployeeRepository employeerepo)
        {
            _employeerepo = employeerepo;
        }
        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult Employees(string searchQuery="")
        {
            //if search query is null or empty
            //render view only
            //otherwise --> select data based on search query and pass to the view to render the result on table.

            if (string.IsNullOrEmpty(searchQuery))
            {
                var result=_employeerepo.GetAll().ToList();
                return View(result);

            }
            else
            {   
                
                var result = _employeerepo.GetAll();
                var filteredResult = result.Where(x =>x.Name.Contains(searchQuery)
                                        || x.Email.Contains(searchQuery));

                return View(filteredResult);
            }
        }
        public IActionResult Addemployee()
        {
            return View();
        }

        public IActionResult GetEmployee()
        {
            var data = _employeerepo.GetAll().ToList();
            return Json(data);
        }


        [HttpPost]
        public IActionResult Addemployee(EmployeeViewModel employeeVm)
        {
            try
            {
                string filename = "maledefault.png";
                if (employeeVm.photo != null)
                {
                    filename = _employeerepo.SaveFileAndReturnName("~/image/maledefault", employeeVm.photo);
                }

                if (_employeerepo.Get(x => x.Email == employeeVm.Email || x.PhoneNumber == employeeVm.PhoneNumber) != null)
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
                    _employeerepo.Add(employees);
                    _employeerepo.save();
                    TempData["SuccessMessage"] = "Data Entered Successfully.";
                    return RedirectToAction("Employees");
                }


            }
            catch (Exception e)
            {
                SetMessage($"Opps !! Cannot Add Data. {e.Message}", "ErrorMessage");
                return RedirectToAction("Employees");
            }
        }
        public IActionResult Update(int id)
        {
            var employee = _employeerepo.Get(x => x.Id == id);
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
            var employee = _employeerepo.Get(x=>x.Id==Updatevm.Id);
            if (employee != null)
            {


                employee.Id = Updatevm.Id;
                employee.Name = Updatevm.Name;
                employee.Email = Updatevm.Email;
                employee.PhoneNumber = Updatevm.PhoneNumber;
                employee.Address = Updatevm.Address;
                employee.Position = Updatevm.Position;
                _employeerepo.save();
                TempData["SuccessMessage"] = "Data saved ";
                return RedirectToAction("Employees");
            }
            TempData["ErrorMessage"] = "No DataEntry";

            return RedirectToAction("Update");

        }
        public IActionResult Delete(int id)
        {
            var employee = _employeerepo.Get(x=>x.Id==id);
            if (employee != null)
            {
                _employeerepo.Remove(employee);
                _employeerepo.save();
                TempData["SuccessMessage"] = "Deleted Successfully.";   
                return RedirectToAction("Employees");
            }
            TempData["ErrorMessage"] = "Not Deleted Successfully.";
            return RedirectToAction("Employees");
        }


        public IActionResult ViewEmployee(int id)
        {
            var employee = _employeerepo.Get(x=>x.Id == id);
            if (employee != null)
            {
                var employeeVm = new EmployeeViewModel()
                {
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address,
                    Position = employee.Position,

                };
                return View(employeeVm);
            }
            else
            {
                return View();
            }
        }
        public void SetMessage(string message, string messageType)
        {
            TempData[messageType] = message;
        }

    }
}


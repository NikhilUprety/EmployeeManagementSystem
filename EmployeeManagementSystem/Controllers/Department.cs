using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class Department : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

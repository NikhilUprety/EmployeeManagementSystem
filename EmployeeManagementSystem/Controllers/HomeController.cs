using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
        public IActionResult logout()
        {
         return RedirectToAction("Index", "Home");
        }
    }
}
        
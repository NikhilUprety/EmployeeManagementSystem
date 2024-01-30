using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Areas.admin.Controllers
{
    [Authorize]

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

using Employee_Mannagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Mannagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.AdminUsername != null && admin.AdminPassword != null)
                {
                    if (admin.AdminUsername == "@dmin" && admin.AdminPassword == "@dmin")
                    {
                        //USERNAME SESSION
                        HttpContext.Session.SetString("AdminUsernameSession", admin.AdminUsername);
                        HttpContext.Session.SetString("AdminPasswordSession", admin.AdminPassword);
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        ViewBag.IsSuccess = "Wrong Username Or Password !!!";
                        ModelState.Clear();
                        return View();
                    }
                }
                else
                {
                    ViewBag.IsSuccess = "Please Login First !!!";
                    ModelState.Clear();
                    return View();
                }
            }
            
            return View();
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Remove("AdminUsernameSession");
            HttpContext.Session.Remove("AdminPasswordSession");
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace T2207A_MVC.Controllers
{
    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Xyz()
        {
            return View();
        }
    }
}

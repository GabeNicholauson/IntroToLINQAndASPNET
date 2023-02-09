using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQAndASPNET.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

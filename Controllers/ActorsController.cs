using Microsoft.AspNetCore.Mvc;
using IntroToLINQAndASPNET.Data;
using IntroToLINQAndASPNET.Models;

namespace IntroToLINQAndASPNET.Controllers
{
    public class ActorsController : Controller
    {
        public IActionResult HighestPaidActor()
        {
            int index = Context.Actors.Count - 1;
            Actor highestPaid = Context.Actors.OrderBy(actor => actor.Salary).ElementAt(index);
            return View("Details", highestPaid);
        }
    }
}

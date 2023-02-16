using Microsoft.AspNetCore.Mvc;
using IntroToLINQAndASPNET.Data;
using IntroToLINQAndASPNET.Models;

namespace IntroToLINQAndASPNET.Controllers
{
    public class ActorsController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Actors);
        }

        public IActionResult GetActorInfo(string name) // retrieves info about the movie
        {
            return View("Details", Context.Actors.FirstOrDefault(x => x.Name.ToLower() == name.ToLower().Trim()));
        }
        public IActionResult HighestPaidActor()
        {
            // the list gets sorted least to greatest so i want the actor in the last position
            int index = Context.Actors.Count - 1;
            // order the list by salary and get me the actor in the last position
            Actor highestPaid = Context.Actors.OrderBy(actor => actor.Salary).ElementAt(index);
            return View(highestPaid);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using IntroToLINQAndASPNET.Models;
using IntroToLINQAndASPNET.Data;

namespace IntroToLINQAndASPNET.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult GetMovieInfo(string name)
        {
            List<Movie> allMovies = new List<Movie>();
            allMovies.Add(Context.Movies.FirstOrDefault(x => x.Name.ToLower() == name.ToLower().Trim()));
            return View("Index", allMovies);
        }

        public IActionResult GetAllInGenre(string genre)
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.Genre.ToLower() == genre.ToLower().Trim();
            }).ToList();
            return View("Index", allMovies);
        }

        public void GetCountInGenre()
        {

        }

        public IActionResult MoviesInBudget(int budget)
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.Budget <= budget;
            }).ToList();
            return View("Index", allMovies);
        }

        public void MoviesInThe90s()
        {

        }

        public void CalculateOverallRating()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

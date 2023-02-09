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
            return View("Details", allMovies);
        }

        public IActionResult GetAllInGenre(string genre)
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.Genre.ToLower() == genre.ToLower().Trim();
            }).ToList();
            return View("Details", allMovies);
        }

        public IActionResult GetCountInGenre(string genre)
        {
            int count = 0;
            string genreCount;
            foreach(Movie movie in Context.Movies)
            {
                if (movie.Genre.ToLower() == genre.ToLower().Trim()) {
                    count++;
                }
            }
            genreCount = $"{genre}: {count}";
            return View("Count", genreCount);
        }

        public IActionResult MoviesInBudget(int budget)
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.Budget <= budget;
            }).ToList();
            return View("Details", allMovies);
        }

        public IActionResult MoviesInThe90s()
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.ReleaseYear >= 1990 && x.ReleaseYear < 2000;
            }).ToList();
            return View("Details", allMovies);
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

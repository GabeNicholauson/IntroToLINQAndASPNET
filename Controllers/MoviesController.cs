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
            genreCount = $"Movies in {genre}: {count}";
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

        public IActionResult CalculateOverallRating(string movie)
        {
            Movie foundMovie = Context.Movies.First(x => x.Name.ToLower() == movie.ToLower().Trim());
            double average = 0;
            string overallRating;
            try
            {
                if (foundMovie.AllRatings.Count == 0)
                {
                    throw new Exception($"{foundMovie.Name} has no ratings.");
                }
                else
                {
                    foreach (Rating rating in foundMovie.AllRatings)
                    {
                        average += rating.Score;
                    }
                    average /= foundMovie.AllRatings.Count;
                }
                overallRating = $"The overall rating for {foundMovie.Name}: {average}";
                return View("Count", overallRating);
            } catch (Exception ex)
            {
                return View("Count", ex.Message);
            }
        }
    }
}

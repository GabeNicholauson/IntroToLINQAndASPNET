using Microsoft.AspNetCore.Mvc;
using IntroToLINQAndASPNET.Models;
using IntroToLINQAndASPNET.Data;

namespace IntroToLINQAndASPNET.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Movies);
        }
        public IActionResult GetMovieInfo(string name) // retrieves info about the movie
        {
            List<Movie> allMovies = new List<Movie>();
            // grab the first movie whose name matches
            allMovies.Add(Context.Movies.FirstOrDefault(x => x.Name.ToLower() == name.ToLower().Trim()));
            return View("Details", allMovies);
        }

        public IActionResult GetAllInGenre(string genre) // gets the the movies within the specified genre
        {
            // Where will go through the entire Movies list in Context
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                // if the movie contains the genre, add it to the list
                return x.Genre.ToLower() == genre.ToLower().Trim();
            }).ToList();
            return View("Details", allMovies);
        }

        public IActionResult GetCountInGenre(string genre) // gets the number of movies with the specified genre
        {
            int count = 0; // tracks how many movies are in the specified genre
            string genreCount; // the string that gets sent to the page
            foreach(Movie movie in Context.Movies) // check each movie
            {
                // if the genre matches
                if (movie.Genre.ToLower() == genre.ToLower().Trim()) {
                    count++; // one more movie
                }
            }
            genreCount = $"Movies in {genre}: {count}";
            return View("Count", genreCount);
        }

        public IActionResult MoviesInBudget(int budget) // returns all the movies within the specified budget
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                // if the budget is equal or lower, then add it
                return x.Budget <= budget;
            }).ToList();
            return View("Details", allMovies);
        }

        public IActionResult MoviesInThe90s() // returns all movies from 1990 to 2000
        {
            List<Movie> allMovies = Context.Movies.Where(x =>
            {
                return x.ReleaseYear >= 1990 && x.ReleaseYear < 2000;
            }).ToList();
            return View("Details", allMovies);
        }

        public IActionResult CalculateOverallRating(string movie) // calculates the average rating
        {
            // grabs the first movie with the matching name
            Movie foundMovie = Context.Movies.First(x => x.Name.ToLower() == movie.ToLower().Trim());
            double average = 0; // tracks the average rating
            string overallRating; // string that gets sent to the page
            try // checks if the movie wven has any ratings
            {
                if (foundMovie.AllRatings.Count == 0) // if there are no ratings
                {
                    throw new Exception($"{foundMovie.Name} has no ratings.");
                }
                else // there are ratings
                {
                    foreach (Rating rating in foundMovie.AllRatings) //go through each rating
                    {
                        average += rating.Score; // add the score to the average
                    }
                    average /= foundMovie.AllRatings.Count; // get the average of the ratings
                }
                overallRating = $"The overall rating for {foundMovie.Name}: {average}";
                return View("Count", overallRating);
            } catch (Exception ex) // if there are no ratings
            {
                return View("Count", ex.Message);
            }
        }
    }
}

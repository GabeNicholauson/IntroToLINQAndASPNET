using IntroToLINQAndASPNET.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace IntroToLINQAndASPNET.Data
{
    public static class Context
    {
        private static int _id = 1;

        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie("Jurassic Park", "Action", 1993, 63_000_000),
            new Movie("Dumb and Dumber", "Comedy", 1994, 17_000_000),
            new Movie("The SpongeBob SquarePants Movie", "Comedy", 2004, 30_000_000),
            new Movie("Avatar", "Action", 2009, 237_000_000),
            new Movie("2001: A Space Odyssey", "Science Fiction", 1968, 10_500_000)
        };
        public static List<Movie> Movies { get { return _movies; } }

        private static List<User> _users = new List<User>()
        {
            new User("Joe", _id++),
            new User("Mary", _id++),
            new User("Harold", _id++)
        };
        public static List<User> Users { get { return _users; } }

        private static List<Rating> _ratings = new List<Rating>()
        {
            new Rating(_users.First(u => u.Name == "Joe"), _movies.First(m => m.Name == "Avatar"), 8.4),
            new Rating(_users.First(u => u.Name == "Joe"), _movies.First(m => m.Name == "Dumb and Dumber"), 99.9),
            new Rating(_users.First(u => u.Name == "Mary"), _movies.First(m => m.Name == "Avatar"), 33.2),
            new Rating(_users.First(u => u.Name == "Harold"), _movies.First(m => m.Name == "Jurassic Park"), 50),
            new Rating(_users.First(u => u.Name == "Joe"), _movies.First(m => m.Name == "2001: A Space Odyssey"), 40)
        };
        public static List<Rating> Ratings { get { return _ratings; } }

        private static List<Actor> _actors = new List<Actor>()
        {
            new Actor("Billy", 900_002),
            new Actor("Kelly", 900_000),
            new Actor("Quart", 900_001)
        };
        public static List<Actor> Actors { get { return _actors; } }

        static Context()
        {
            foreach (User user in Users) // goes through each actor in the list
            {
                // adds the ratings with matching user names to their ratings list
                user.AllRatings = Ratings.Where(x =>
                {
                    return x.User.Name == user.Name;
                }).ToList();
            }

            foreach (Movie movie in Movies) // goes through each movie in the list
            {
                // gives them their ratings from AllRatings
                movie.AllRatings = Ratings.Where(x =>
                {
                    return x.Movie.Name == movie.Name; // if the names match
                }).ToList();
            }

        }
    }
}

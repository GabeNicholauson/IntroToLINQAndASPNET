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
            new Rating(GetUser("Joe"), GetMovie("Avatar"), 9),
            new Rating(GetUser("Joe"), GetMovie("Dumb and Dumber"), 7),
            new Rating(GetUser("Mary"), GetMovie("Avatar"), 8),
            new Rating(GetUser("Harold"), GetMovie("Jurassic Park"), 4),
            new Rating(GetUser("Joe"), GetMovie("2001: A Space Odyssey"), 2)
        };
        public static List<Rating> Ratings { get { return _ratings; } }

        private static List<Actor> _actors = new List<Actor>()
        {
            new Actor("Billy", 900_002),
            new Actor("Kelly", 900_000),
            new Actor("Quart", 900_001)
        };
        public static List<Actor> Actors { get { return _actors; } }

        private static User GetUser(string name)
        {
            return Users.First(x => x.Name == name);
            throw new Exception("That user doesn't exist");
        }
        private static Movie GetMovie(string name)
        {
            return Movies.First(x => x.Name == name);
            throw new Exception("That movie doesn't exist");
        }

        private static void AddMovieRatings()
        {
            foreach (Movie movie in Movies) // goes through each movie in the list
            {
                // gives them their ratings from AllRatings
                movie.AllRatings = Ratings.Where(x =>
                {
                    return x.Movie.Name == movie.Name; // if the names match
                }).ToList();
            }
        }

        private static void AddUserRatings()
        {
            foreach (User user in Users) // goes through each actor in the list
            {
                // adds the ratings with matching user names to their ratings list
                user.AllRatings = Ratings.Where(x =>
                {
                    return x.User.Name == user.Name;
                }).ToList();
            }
        }

        private static void AddRoll(string name, string role, string movieTitle)
        {
            Actor actor = _actors.First(a => a.Name == name);
            Movie movie = _movies.First(m => m.Name == movieTitle);
            actor.AllRoles.Add(movie, role);
            movie.AllActors.Add(actor, role);
        }

        public static void CreateRating(string user, string movie, int score, string comment)
        {
            Rating newRating = new Rating(GetUser(user), GetMovie(movie), score);
            newRating.SetComment(comment);
            _ratings.Add(newRating);
            GetUser(user).AllRatings.Add(newRating);
            GetMovie(movie).AllRatings.Add(newRating);
        }

        static Context()
        {
            AddMovieRatings();
            AddUserRatings();

            AddRoll("Billy", "Captain Jurassic", "Jurassic Park");
            AddRoll("Kelly", "Anti-Jurassic", "Jurassic Park");

            AddRoll("Kelly", "Dumber", "Dumb and Dumber");

            AddRoll("Quart", "The 3rd Avatar", "Avatar");
            AddRoll("Billy", "The McDonald's Avatar", "Avatar");

            AddRoll("Billy", "Karen", "The SpongeBob SquarePants Movie");

            AddRoll("Kelly", "HAL 9000", "2001: A Space Odyssey");
        }
    }
}

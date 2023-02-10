using IntroToLINQAndASPNET.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace IntroToLINQAndASPNET.Data
{
    public static class Context
    {
        private static int _id = 1;

        private static Movie _jurrasicPark = new Movie("Jurassic Park", "Action", 1993, 63_000_000);
        private static Movie _dumbAndDumber = new Movie("Dumb and Dumber", "Comedy", 1994, 17_000_000);
        private static Movie _theSpongBobSquarePantsMovie = new Movie("The SpongeBob SquarePants Movie", "Comedy", 2004, 30_000_000);
        private static Movie _avatar = new Movie("Avatar", "Action", 2009, 237_000_000);
        private static Movie _2001ASpaceOdyssey = new Movie("2001: A Space Odyssey", "Science Fiction", 1968, 10_500_000);

        private static User _joe = new User("Joe", _id++);
        private static User _mary = new User("Mary", _id++);
        private static User _harold = new User("Harold", _id++);

        private static Rating _rating1 = new Rating(_joe, _avatar, 8.4);
        private static Rating _rating2 = new Rating(_joe, _dumbAndDumber, 99.9);
        private static Rating _rating3 = new Rating(_mary, _avatar, 33.2);
        private static Rating _rating4 = new Rating(_harold, _jurrasicPark, 50);
        private static Rating _rating5 = new Rating(_joe, _2001ASpaceOdyssey, 40);

        private static Actor _billy = new Actor("Billy", 900_002);
        private static Actor _kelly = new Actor("Kelly", 900_000);
        private static Actor _quart = new Actor("Quart", 900_001);

        public static List<Movie> Movies = new List<Movie>()
        {
            _jurrasicPark,
            _dumbAndDumber,
            _theSpongBobSquarePantsMovie,
            _avatar,
            _2001ASpaceOdyssey
        };

        public static List<User> Users = new List<User>()
        {
            _joe,
            _mary,
            _harold
        };

        public static List<Rating> Ratings = new List<Rating>()
        {
            _rating1,
            _rating2,
            _rating3,
            _rating4,
            _rating5
        };

        public static List<Actor> Actors = new List<Actor>()
        {
            _billy,
            _kelly,
            _quart
        };

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

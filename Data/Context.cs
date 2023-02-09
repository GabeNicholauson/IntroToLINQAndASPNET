using IntroToLINQAndASPNET.Models;

namespace IntroToLINQAndASPNET.Data
{
    public static class Context
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie("Jurassic Park", "Action", 1993, 63_000_000),
            new Movie("Dumb and Dumber", "Comedy", 1994, 17_000_000),
            new Movie("The SpongeBob SquarePants Movie", "Comedy", 2004, 30_000_000),
            new Movie("Avatar", "Action", 2009, 237_000_000),
            new Movie("2001: A Space Odyssey", "Science Fiction", 1968, 10_500_000)
        };

    }
}

namespace IntroToLINQAndASPNET.Models
{
    public class Movie
    {
        private string _name;
        public string Name { get { return _name; } }

        private string _genre;
        public string Genre { get { return _genre; } }

        private int _releaseYear;
        public int ReleaseYear { get { return _releaseYear; } }

        private int _budget;
        public int Budget { get { return _budget; } }

        public List<Rating> AllRatings = new List<Rating>();

        public List<Actor> AllActors = new List<Actor>();

        public Movie(string name, string gnere, int year, int budget)
        {
            _name = name;
            _genre = gnere;
            _releaseYear = year;
            _budget = budget;
        }
    }
}

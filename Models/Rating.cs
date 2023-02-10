namespace IntroToLINQAndASPNET.Models
{
    public class Rating
    {
        private User _user;
        public User User { get { return _user; } }

        private Movie _movie;
        public Movie Movie { get { return _movie; } }   

        private double _score;
        public double Score { get { return _score; } }    
        public Rating(User user, Movie movie, double score) 
        {
            _user = user;
            _movie = movie;
            _score = score;
        } 
    }
}

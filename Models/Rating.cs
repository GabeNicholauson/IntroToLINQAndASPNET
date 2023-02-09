namespace IntroToLINQAndASPNET.Models
{
    public class Rating
    {
        private User _user;
        public User User { get { return _user; } }

        private double _score;
        public double Score { get { return _score; } }    
        public Rating(User user, double score) 
        {
            _user = user;
            _score = score;
        } 
    }
}

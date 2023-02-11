namespace IntroToLINQAndASPNET.Models
{
    public class Rating
    {
        private User _user;
        public User User { get { return _user; } }

        private Movie _movie;
        public Movie Movie { get { return _movie; } }   

        private int _score;
        public int Score { get { return _score; } }

        private string _comment;
        public string Comment { get { return _comment; } }
        public void AddComment(string comment)
        {
            _comment = comment;
        }
        public Rating(User user, Movie movie, int score) 
        {
            _user = user;
            _movie = movie;
            _score = score;
        } 
    }
}

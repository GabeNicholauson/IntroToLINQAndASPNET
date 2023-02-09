namespace IntroToLINQAndASPNET.Models
{
    public class User
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _id;
        public int Id { get { return _id; } }

        public List<Rating> _allRatings = new List<Rating>();

        public User(string name, int id)
        {
            _name = name;
            _id = id;
        }
    }
}

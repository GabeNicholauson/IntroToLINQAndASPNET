namespace IntroToLINQAndASPNET.Models
{
    public class Actor
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _salary;
        public int Salary { get { return _salary; } }

        private Dictionary<Movie, string> _allRoles = new Dictionary<Movie, string>();
        public Dictionary<Movie, string> AllRoles { get { return _allRoles; } }

        public List<Rating> AllRatings = new List<Rating>();
        public Actor(string name, int salary)
        {
            _name = name;
            _salary = salary;
        }
    }
}

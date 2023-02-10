﻿namespace IntroToLINQAndASPNET.Models
{
    public class Actor
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _salary;
        public int Salary { get { return _salary; } }

        public Dictionary<Movie, string> AllRoles = new Dictionary<Movie, string>();

        public Actor(string name, int salary)
        {
            _name = name;
            _salary = salary;
        }
    }
}

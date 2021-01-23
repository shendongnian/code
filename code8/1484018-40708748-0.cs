    public class User
    {
        private string _name;
    
        public User(string Name)
        {
            _name = Name;
        }
    }
    var users = new List<User>();
    users.Add(new User("foo"));
    users.Add(new User("bar"));
    Console.Writeline(users.Count); // this will say 2!
    // you can now use your list of users.

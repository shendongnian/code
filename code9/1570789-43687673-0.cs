    public class User
    {
        public List<string> tags { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    
    public class RootObject
    {
        public List<User> users { get; set; }
    }

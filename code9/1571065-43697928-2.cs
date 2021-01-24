    public class RootObject
    {
        public IEnumerable<User> clients { get; set; }
    }
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

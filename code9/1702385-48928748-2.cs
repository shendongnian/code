	public class User
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class Root
    {
        public User user { get; set; }
    }

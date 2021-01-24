    public class Configuration
    {
        public User UserA { get; set; } = new User();
        public User UserB { get; set; } = new User();
        ...
    }
    public class User
    {
        public string ServiceString { get; set; } = "whatever";
    }

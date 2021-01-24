    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    
    public class DataUser : User
    {
        public Guid Id { get; set }
        public string Role { get; set; }
    }

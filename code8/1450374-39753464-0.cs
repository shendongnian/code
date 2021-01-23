    public class User
    {
        public User()
        {
            UserType = new UserType();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public DbUser DbUser
        {
            set
            {
                Username = value.UserName;
                Email = value.Email;
                Birthday = value.Birthday;
            }
        }
    }

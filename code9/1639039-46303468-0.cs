    public class User
    {
        // Add this
        public User()
        {
        }
        public User(string userName, string email, string password) : this(userName, email, password, null, null)
        {
        }
        public User(string userName, string email, string password, string Name, string firstName)
        {
            this.Username = userName;
            this.Email = email;
            this.Password = password;
            this.Name = Name;
            this.firstName = firstName;
        } 
        [...]
    }

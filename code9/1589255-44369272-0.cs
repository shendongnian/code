    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Username = "user99"
            };
            Account account = new Account(user);
        }
    }
    public interface IUser
    {
        string Username { get; }
    }
    public class User : IUser
    {
        public string Username { get; set; }
    }
    public class Account
    {
        private IUser user;
        //Currently used in main
        public Account(User user)
        {
            user.Username = ""; //This is allowed            
            this.user = user;
        }
        //But consider this ctor
        public Account(IUser user)
        {
            //user.Username = ""; //Not allowed
            this.user = user;
        }
        ...
    }

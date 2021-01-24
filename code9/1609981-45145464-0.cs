    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public void ReceiveUserString(string source)
    {
        string[] UserString = source.Split(',');
        var User = new User();
        foreach (string u in UserString)
        {
            User.Username = u[0];
            User.Password = u[1];
        }
    }

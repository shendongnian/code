    public class RegisterLotsModel
    {
        public List<UserToRegister> ApplicationUsers { get; set; }
    }
    public class UserToRegister
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

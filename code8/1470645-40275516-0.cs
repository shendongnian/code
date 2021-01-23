    [Validator(typeof(LoginRegisterModelValidator))]
    public class LoginRegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName{ get; set; }
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "(Translation for 'this email is invalid' here)")]
        public string Email { get; set; }
    }

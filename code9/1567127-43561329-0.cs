    public class ForgotPasswordMV
    {
        [Display(Name = "Enter your email"), Required]
        public string Email { get; set; }
    
        public string ErrorMessage { get; set; }
    }

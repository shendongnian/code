    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email or Phone")]
        /* /<email-pattern>|<phone-pattern>/ */
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]      
        public string EmailOrPhone { get; set; }
    }

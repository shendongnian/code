     public class RegisterViewModel
     {
        [Required]
        [Display(Name = "Email or Phone")]
        [EmailOrPhone]    
        public string EmailOrPhone { get; set; }
     }

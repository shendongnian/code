    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User name")]
        [StringLength(500, ErrorMessage = "User name is too short", MinimumLength = 3)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

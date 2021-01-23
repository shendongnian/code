    public class MemberLoginViewModel
    {
        [Required(ErrorMessage = "")]
        [Display(Name = "")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "")]
        [Required(ErrorMessage = "")]
        public string Password { get; set; }
        [Display(Name = "")]
        public bool RememberMe { get; set; }
    }

    public class MemberRegisterViewModel
    {
        [Required(ErrorMessage = "")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "")]
        [DataType(DataType.Password)]
        [Display(Name = "")]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }

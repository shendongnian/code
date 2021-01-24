    public class RegisterViewModel
    {
        // Properties associated with ApplicationUser
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }
        ....
        public bool IsTradesPerson { get; set; }
        // Properties associated with CompanyModel
        [Display(Name = "Company Name")]
        [RequiredIfTrue("IsTradesPerson", ErrorMessage = "Please enter your Company Name")]
        public string CompanyName { get; set; }
        ....
    }

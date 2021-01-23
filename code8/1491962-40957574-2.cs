    public class RegisterViewModel
    {
        ....
        [Required(ErrorMessage = "Please select a user type")]
        [Display(Name = "Select user type:")]
        public string Role { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
     }

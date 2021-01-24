    public class EditEmployeeViewModel
    {
        [Required(ErrorMessage ="Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string EmailAddress { get; set; }
    }

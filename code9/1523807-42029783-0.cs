    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage ="Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("checkEmailValidate", "Employee", HttpMethod = "POST", ErrorMessage ="User with this Email already exists")]
        public virtual string EmailAddress { get; set; }
    }

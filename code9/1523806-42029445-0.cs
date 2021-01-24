    public class Employee
    {
        [Required(ErrorMessage ="Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string EmailAddress { get; set; }
    }
    public class CreateEmployee : Employee
    {
        //Existing members of Employee should be preserved. if there are any so your code should continue to work.
        [Required(ErrorMessage ="Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("checkEmailValidate", "Employee", HttpMethod = "POST", ErrorMessage ="User with this Email already exists")]
        public override string EmailAddress { get; set; }
    }

    [MetadataType(typeof(MyEmail))]
    public class Person
    {
        public string Email { get; set; }
    }
    
    [MetadataType(typeof(MyEmail))]
    public class Invoice
    {
        public string Email { get; set; }
    }
    
    public abstract class MyEmail
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [CustomDataAnnotation()]
        public string Email { get; set; }
    }

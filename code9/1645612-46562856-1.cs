    public class Person
    {
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
    
        [Required(ErrorMessage = "Second Name is required!")]
        public int SecondName { get; set; }
    }

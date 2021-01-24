     public class Employee
    {       
        [Key]
        [Required]       
        public int EmployeeId { get; set; }
      
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
    }

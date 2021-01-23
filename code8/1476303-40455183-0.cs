    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string NRIC { get; set; }
        [Required]
        public string StaffIdentity { get; set; }
        [Required]
        public int AccessRights { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string ImageName { get; set; }
    }

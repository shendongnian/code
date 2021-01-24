    public class ApplicationUser : IdentityUser
    { 
        public Guid MyGuid { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }

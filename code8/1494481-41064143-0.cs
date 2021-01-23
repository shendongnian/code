        public class Employee : BaseEntity
        {
            public int EmployeeId { get; set; }
    
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public string Email { get; set; }
    
            public string PhoneNumber { get; set; }
    
            public int HomeLocationId { get; set; }
    
           
    
    
            //Navigation Properties
            public virtual Location HomeLocation { get; set; }
    
            public virtual EmployeeRate EmployeeRate { get; set; }
        }

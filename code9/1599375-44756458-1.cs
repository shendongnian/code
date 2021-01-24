    public class EmployeeEntity : CustomEntity
    {
        public EmployeeEntity(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }
    
        public EmployeeEntity() { }
    
        public string Email { get; set; }
    
        public Address ContactAddress { get; set; }
    }
    
    public class Address
    {
        public string Province { get; set; }
    
        public string City { get; set; }
    }

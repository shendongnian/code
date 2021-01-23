    public class Employee
    {
        public int EmployeeId { get; set; };
        // ...
        public virutal ICollection<Address> Addresses { get; set; };
    }
    
    public class Company
    {
        public int CompanyId { get; set; };
        // ...
        public ICollection<Address> Addresses { get; set; };
    }
    
    public class Address
    {
        public int AddressId { get; set; };
        public int? EmployeeId { get; set; };
        public int? CompanyId { get; set; };
        // ...
        public virtual Employee Employee { get; set; };
        public virtual Company Company { get; set; };
    }

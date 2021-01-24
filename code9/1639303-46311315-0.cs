    class Customer
    {
    public string Name {get;set;}
    public string LastName {get; set;}
    }
    
    class Vendor
    {
         public string Name {get; set;}
         public List<Customer> Customers {get;set}
    }
    
    class Organization
    {
         public string Name {get; set;}
         public List<Vendor> Vendors {get;set;}
    }

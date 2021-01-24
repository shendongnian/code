    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        //remove virtual keyword as there is no lazy loading in  entityframework core
        public ICollection<Address> Addresses { get; set; }
    }
    
    public class Address
    {
        public Guid Id { get; set; }
    
        [ForeignKey("Company ")]
        public Guid RealtionId { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        
        //remove virtual keyword as there is no lazy loading in  entityframework core
        public Company Company {get; set;}
    }

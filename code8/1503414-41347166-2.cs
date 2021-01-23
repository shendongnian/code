    public class Person
    {
        public Guid Id { get; set; }
        public ICollection<Address> { get; set; }
        // other properties
    }
    
    public class Address
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        // other properties
    }

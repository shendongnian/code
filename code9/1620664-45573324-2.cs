    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public Address MyAddress { get; set; }
    }
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
    }

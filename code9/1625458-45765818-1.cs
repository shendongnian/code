    public class Person
    {
        public string Name { get; set; }
        public List<Address> Address = new List<Address>();
    }
    
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class Address
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
    }
    
    public class PhoneNumber
    {
        public string type { get; set; }
        public string number { get; set; }
    }
    
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public Address address { get; set; }
        public List<PhoneNumber> phoneNumber { get; set; }
    }

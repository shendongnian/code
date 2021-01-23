    class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public Address address { get; set; } // here
        public IEnumerable<PhoneNumber> phoneNumber { get; set; } // and here
        public class Address { /.../ }
        public class PhoneNumber { /.../ }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int AddressId 
        { 
            get{ return AddressInfo?.AddressId ?? 0 } 
            set{ AddressInfo?.AddressId = value; }
        }
        public Address AddressInfo { get; set; }
    }
    public class Address
    {
        public int AddressId { get; set; }
        public string streetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

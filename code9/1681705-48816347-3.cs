    public sealed class Address : ValueObject<Address>
    {
        public string StreetAddress1 { get; private set; }
        public string StreetAddress2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        private Address() { }
        public Address(string streetAddress1, string city, string state, string zipcode, string country)
        {
            StreetAddress1 = streetAddress1;
            City = city;
            State = state;
            ZipCode = zipcode;
            Country = country;
        }
        public Address(string streetAddress1, string streetAddress2, string city, string state, string zipcode, string country)
            : this(streetAddress1, city, state, zipcode, country)
        {
            StreetAddress2 = streetAddress2;
        }
        public static Address Empty()
        {
            return new Address("", "", "", "", "");
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(StreetAddress1)
             && string.IsNullOrEmpty(City)
             && string.IsNullOrEmpty(State)
             && string.IsNullOrEmpty(ZipCode)
             && string.IsNullOrEmpty(Country))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
    }
    public class Firm : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
      
        private Firm() { }
        public Firm(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException();
            Id = Guid.NewGuid();
            Name = name;
            Address = Address.Empty();
        }
    }
 

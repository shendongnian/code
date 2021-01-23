    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    
    public class Class1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Salt { get; set; }
        public Address Address { get; set; }
        public Telephone Telephone { get; set; }
        public Location Location { get; set; }
    }
    
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
    
    public class Telephone
    {
        public string PersonalPhoneNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
    }
    
    public class Location
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }

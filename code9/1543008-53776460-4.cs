    public class User
    {
        [NoLog]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime AnneviseryDate { get; set; }
        [NoLog]
        public int LinkId { get; set; }
        public List<Address> Addresses { get; set; }
    }
    public class Address
    {
        public string AddressLine { get; set; }
        [NoLog]
        public string City { get; set; }
        [NoLog]
        public string Country { get; set; }
    }

    public class Address : BaseEntity // Not abstract
    {
        public int HumanId { get; set; }
        public Human Human { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; } set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
    }

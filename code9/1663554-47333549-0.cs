    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        
        public override string ToString()
        {
            return $"First name: {FirstName}, Last name: {LastName}, Address: {Address}, City: {City}, Country: {Country}, Post code: {PostCode}";
        }
    }

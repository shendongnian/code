    class Customer 
    {
        public string Name { get; set; }
        public Address CustomerAddress { get; set; } = new Address(); // initial value
        
        // private property used to get value from json
        // attribute is needed to use not-matching names (e.g. if Customer already have City)
        [JsonProperty(nameof(Address.City))]
        string _city
        {
            set { CustomerAddress.City = value; }
        }
        // ... same for other properties of Address
    }

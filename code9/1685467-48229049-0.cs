    class Person
    {
        [JsonProperty(PropertyName = "address 1")]
        public string Address1 { get; set; }
        [JsonProperty(PropertyName = "zipcode")]
        public int ZipCode { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
    }

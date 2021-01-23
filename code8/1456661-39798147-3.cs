    public class Adddress
    {
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("Line1")]
        public string Line1 { get; set; }
        [JsonProperty("Line2")]
        public string Line2 { get; set; }
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("State")]
        public string State { get; set; }
        [JsonProperty("AddressCode")]
        public string AddressCode { get; set; }
    }
    public class AddressList
    {
        [JsonProperty("Adddress")]
        public IList<Adddress> Adddress { get; set; }
    }

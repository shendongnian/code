    public class PropertyViewModel {
        [JsonProperty("listingID")]
        public string ListingID { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
        [JsonProperty("streetName")]
        public string StreetName { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

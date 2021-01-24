    public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("address")]
		// Make this an Address not a string
        public Address Address { get; set; }
    }

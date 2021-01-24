    [JsonConverter(typeof(JsonDeserializationPropertyMatchConverter))]
    public class Package
    {
        public string Carrier { get; set; }
    
        [JsonDeserializationName("Tracking_Number","anotherName")]
        public string TrackingNumber { get; set; }
    }

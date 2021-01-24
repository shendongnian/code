    using System.Text.Json.Serialization;
    public class Package
    {
        [JsonPropertyName("carrier")]
        public string Carrier { get; set; }
    
        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; set; }
    }

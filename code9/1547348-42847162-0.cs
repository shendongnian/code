    public class Package
    {
    	[JsonProperty(PropertyName = "carrier")]
        public string Carrier { get; set; }
    	
        [JsonProperty(PropertyName = "trackingNumber")]
    	public string TrackingNumber { get; set; }
    }

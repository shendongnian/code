    public class UserDocument
        {
            [JsonProperty(PropertyName = "type")]
            public string type { get; set; }
    
            [JsonProperty(PropertyName = "taxYear")]
            public string taxYear { get; set; }
    
            [JsonProperty(PropertyName = "createdDate")]
            public double createdDate { get; set; }
    
            [JsonProperty(PropertyName = "processedDate")]
            public double processedDate { get; set; }
    
        }

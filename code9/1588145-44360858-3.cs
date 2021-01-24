     public class Product
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
    
            // used to set expiration policy
            [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
            public int? TimeToLive { get; set; }
    
            public string ProductId { get; set; }
            public DateTime DateStarted { get; set; }
        }

     public class TestModel
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
    
            // used to set expiration policy
            [JsonProperty(PropertyName = "ttl", NullValueHandling = NullValueHandling.Ignore)]
            public int? TimeToLive { get; set; }
            public string PartyId { get; set; }
            public string Type { get; set; }
            public DateTime DateStarted { get; set; }
            public int WorkoutId { get; set; }
        }

    public class RootObject
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; } //This property
    
            [JsonProperty("next")]
            public Next Next { get; set; }
        }

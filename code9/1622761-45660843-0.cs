    public class Rootobject
        {
            [JsonProperty("State")]
            public string State { get; set; }
            [JsonProperty("District")]
            public string District { get; set; }
            [JsonProperty("Fact")]
            public Fact Fact { get; set; }
            [JsonProperty("Description")]
            public string Description { get; set; }
            [JsonProperty("CaseDate")]
            public string CaseDate { get; set; }
            [JsonProperty("FactNumber")]
            public string FactNumber { get; set; }
            [JsonProperty("FactType")]
            public string FactType { get; set; }
        }
        
        public class Fact
        {
            [JsonProperty("Id")]
            public string Id { get; set; }
        }

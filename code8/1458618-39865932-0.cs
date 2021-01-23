        public class People
        {
            [JsonProperty(PropertyName ="name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "address")]
            public string  Address { get; set; }
        }

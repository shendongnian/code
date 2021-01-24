        [JsonObject]
        public class PocoObject
        {
            [JsonProperty("$schema", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public string Schema { get; set; }
            [JsonProperty("name", Required = Required.Always)]
            public string Name { get; set; }
            [JsonProperty("properties", Required = Required.Always)]
            public MorePropertiesObject Properties { get; set; }
        }

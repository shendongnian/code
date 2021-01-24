    class Wrapper
    {
        class Application
        {
            [JsonProperty("dataModel", NullValueHandling = NullValueHandling.Ignore)]
            public DataModel dataModel { get; set; }
        }
    
        class DataModel
        {
            [JsonProperty("id", Required = Required.Always)]
            public String id { get; set; }
        }
    }

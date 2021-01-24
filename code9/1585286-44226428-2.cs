    public class ModelPageLocationList {
        [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; }
        [JsonProperty("value")]
        public List<Value> value { get; set; }
    }

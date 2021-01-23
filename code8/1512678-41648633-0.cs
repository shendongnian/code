    public class Sample
    {
        [JsonProperty("data")]
        public List<List<double>> Data { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }

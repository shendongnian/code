    public class Records
    {
        [JsonProperty(PropertyName = "records")]
        public List<int> records { get; set; }
        [JsonProperty("items")]
        private List<int> items { set { records.AddRange(value); } }
    }

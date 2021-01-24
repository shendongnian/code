    public class MyItem
    {
        [JsonProperty("start")]
        [JsonConverter(typeof(LocalTimeConverter))]
        [Keyword]
        public LocalTime Start { get; set; }
    }

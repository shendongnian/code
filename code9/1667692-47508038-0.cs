    public class Holiday {
        [JsonProperty("datum")]
        public DateTime Date { get; set; }
        [JsonProperty("hinweis")]
        public string Note { get; set; }
    }

    public class Root : Dictionary<string, State> { }
    public class State : Dictionary<string, Holiday> { }
    public class Holiday {
        [JsonProperty(PropertyName = "datum")]
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "hinweis")]
        public string Note { get; set; }
    }

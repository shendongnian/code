    class History<T> where T : new()
    {
        public HistoryMatch<T> HistoryMatch { get; set; }
        [JsonProperty("match")]
        public Dictionary<string, T> Match { get; set; }
        [JsonProperty("team")]
        public Dictionary<string, string> Team { get; set; }
        [JsonProperty("note")]
        public Note Note { get; set; }
    }

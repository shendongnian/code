    public class TraceEvent
    {
        [JsonProperty("attributes")]
        public TraceAttributes Attributes { get; set; }
        [JsonProperty("Codes")]
        public List<TraceCode> Codes { get; set; }
    }

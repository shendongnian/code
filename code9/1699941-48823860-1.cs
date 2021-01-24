    public class TraceCodes
    {
        public TraceCodes()
        {
            Codes = new List<TraceCode>();
        }
        [JsonProperty("Codes")]
        public List<TraceCode> Codes { get; set; }
    }

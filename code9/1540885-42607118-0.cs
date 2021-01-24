    public class Port
    {
        [JsonProperty("$")]
        public string PortName { get; set; }
        [JsonProperty("@enabled")]
        public bool Enabled { get; set; }
    }

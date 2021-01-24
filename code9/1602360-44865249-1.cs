    [JsonConverter(typeof(TypedExtensionDataConverter<RootObject>))]
    public class RootObject
    {
        public RootObject()
        {
            // Ensure dictionaries are allocated.
            this.MetaData = new Dictionary<string, string>();
            this.TimeSeries = new Dictionary<string, Dictionary<DateTime, Dictionary<string, decimal>>>();
        }
        [JsonProperty("Meta Data")]
        public Dictionary<string, string> MetaData { get; set; }
        [JsonTypedExtensionData]
        public Dictionary<string, Dictionary<DateTime, Dictionary<string, decimal>>> TimeSeries { get; set; }
    }

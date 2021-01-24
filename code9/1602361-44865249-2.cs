    [JsonConverter(typeof(TypedExtensionDataConverter<RootObject>))]
    public class RootObject
    {
        public RootObject()
        {
            // Ensure dictionaries are allocated.
            this.MetaData = new Dictionary<string, string>();
            this.TimeSeries = new Dictionary<string, Dictionary<DateTime, TimeSeriesData>>();
        }
        [JsonProperty("Meta Data")]
        public Dictionary<string, string> MetaData { get; set; }
        [JsonTypedExtensionData]
        public Dictionary<string, Dictionary<DateTime, TimeSeriesData>> TimeSeries { get; set; }
    }
    public class TimeSeriesData
    {
        [JsonProperty("1. open")]
        public decimal Open { get; set; }
        [JsonProperty("2. high")]
        public decimal High { get; set; }
        [JsonProperty("3. low")]
        public decimal Low { get; set; }
        [JsonProperty("4. close")]
        public decimal Close { get; set; }
        [JsonProperty("5. volume")]
        public decimal Volume { get; set; }
    }

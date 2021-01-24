    public class Root
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public MetaData metaData { get; set; }
        [JsonProperty(PropertyName = "Time Series (15min)")] // You will need to change 15min to the interval you will use
        public Dictionary<string, TimeSeriesIntraDayJsonClass> Data { get; set; }
    }
    
    public class MetaData
    {
        [JsonProperty(PropertyName = "1. Information")]
        public string Information { get; set; }
        [JsonProperty(PropertyName = "2. Symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }
        [JsonProperty(PropertyName = "4. Interval")]
        public string Interval { get; set; }
        [JsonProperty(PropertyName = "5. Output Size")]
        public string OutputSize { get; set; }
        [JsonProperty(PropertyName = "6. Time Zone")]
        public string TimeZone { get; set; }
    }
    public class TimeSeriesIntraDayJsonClass
    {
        [JsonProperty(PropertyName = "1. open")]
        public double open { get; set; }
        [JsonProperty(PropertyName = "2. high")]
        public double high { get; set; }
        [JsonProperty(PropertyName = "3. low")]
        public double low { get; set; }
        [JsonProperty(PropertyName = "4. close")]
        public double close { get; set; }
        [JsonProperty(PropertyName = "5. volume")]
        public double volume { get; set; }
    }

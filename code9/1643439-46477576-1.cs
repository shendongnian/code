    [JsonObject(NamingStrategyType = typeof(CustomNamingStrategy))]
    public class RootObject
    {
        public string JobType { get; set; }
        public string JobNumber { get; set; }
        public int JobItemCount { get; set; }
        public string ISOCode { get; set; }
        public string SourceXML { get; set; }
    }

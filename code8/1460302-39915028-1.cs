    public class ReportRow {
        public int Index { get; set; }
        [JsonProperty("ProductCode")]
        public string ProductCode { get; set; } = string.Empty;
        [JsonProperty("Description")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("SalesLitres")]
        public double SalesLitres { get; set; } = 0.0;
        [JsonProperty("SalesValue")]
        public double SalesValue { get; set; } = 0.0;    
    }

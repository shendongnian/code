    public class StatModel
    {
        const string StatName = "label";
        [JsonProperty(StatName)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Stat Stat { get; set; }
        public string Value { get; set; }
        public int? Rank { get; set; }
        public double? Percentile { get; set; }
        [OnError]
        void OnError(StreamingContext context, ErrorContext errorContext)
        {
            if (errorContext.OriginalObject == this && StatName.Equals(errorContext.Member))
            {
                errorContext.Handled = true;
            }
        }
    }

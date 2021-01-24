    [JsonConverter(typeof(FuzzySnakeCaseMatchingJsonConverter))]
    public class JsonTestData
    {
        public string TestId { get; set; }
        public double MinimumDistance { get; set; }
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool TaxIncluded { get; set; }
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool IsMetsFan { get; set; }
    }

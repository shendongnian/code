    [JsonConverter(typeof(YearConverter))]
    public class Year
    {
        public int Value { get; set; }
        public Dictionary<string, Data> Data { get; set; }
    }

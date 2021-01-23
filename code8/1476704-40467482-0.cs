    [JsonObject]
    public class MyObject : IEnumerable<List<string>>
    {
        public List<string> columns { get; set; }
        public List<List<string>> rows { get; set; }
        public DisplayValue displayValue { get; set; }
        public string currency { get; set; }
        public object alert { get; set; }
        // Implementation of IEnumerable<List<string>>...
    }

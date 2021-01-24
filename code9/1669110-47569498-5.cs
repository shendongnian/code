    [JsonConverter(typeof(ResponseConverter))]
    public class Response
    {
        public string Status { get; set; }
        public List<SampleData> Series { get; set; }
    }

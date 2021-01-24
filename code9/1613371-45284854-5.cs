    class MyDTO
    {
        [JsonConverter(typeof(ListToCsvConverter))]
        public List<string> Friends { get; set; } = new List<string> { "Jan", "Joe", "Tim" };
    }

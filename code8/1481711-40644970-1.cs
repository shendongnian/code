    class InputModel
    {
        public string Name { get; set; }
        [JsonConverter(typeof(DateParseHandlingConverter), DateParseHandling.None)]
        public object Value { get; set; }
    }

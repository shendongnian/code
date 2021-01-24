    class TestData
    {
        [JsonConverter(typeof(FloatParseHandlingConverter), FloatParseHandling.Decimal)]
        public List<Row> rows;
    }

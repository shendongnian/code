    public class TestData
    {
        public string Name;
        [Newtonsoft.Json.JsonConverter(typeof(TupleListConverter<DateTime, double>))]
        public List<Tuple<DateTime, double>> Data;
    }
    public void Test(string json)
    {
        var testData = JsonConvert.DeserializeObject<TestData>(json);
        foreach (var tuple in testData.data)
        {
            var dateTime = tuple.Item1;
            var price = tuple.Item2;
            ... do something...
        }
    }

    var testData = JsonConvert.DeserializeObject<TestData>(jsonString);
    public class TestData
    {
      public string Name;
      [Newtonsoft.Json.JsonConverter(typeof(TupleListConverter<DateTime, double>))]
      public List<Tuple<DateTime, double>> Data;
    }

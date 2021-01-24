    public class TestData
    {
      public string Name;
      [Newtonsoft.Json.JsonConverter(typeof(TupleListConverter<DateTime, string>))]
      public List<Tuple<DateTime, double>> Data;
    }

    public class JsonHistory
    {
      public int id { get; set; }
      public string data { get; set; }
    }
    List<JsonHistory> history = new List<JsonHistory>();
    var histData= JsonConvert.DeserializeObject<JsonHistory>(parsedData);
    history.Add(histData);

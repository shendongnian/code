    public class JsonHistory
    {
      public int id { get; set; }
      public string data { get; set; }
    }
    var histData= JsonConvert.DeserializeObject<JsonHistory>(parsedData);
    foreach (JsonHistory j in histData)
    {
      history.Add(j.data);
    }

    public static void Main(string[] args)
    {
        string json = @"{
      ""Date"": ""2016-12-14"",
      ""Stats"": {
        ""A"": 9.23,
        ""B"": 5.63,
        ""C"": 0
      }
    }";
        
        JObject result = JsonConvert.DeserializeObject<JObject>(json);
        JObject statsObj = (JObject)result["Stats"];
        for(int i = statsObj.Properties().Count()-1; i>=0; i--)
        {
            var propValue = statsObj.Properties().Skip(i).FirstOrDefault();
            if (decimal.Parse(propValue.Value.ToString()) <= 0)
                propValue.Remove();
        }
        string endResult = result.ToString();
    }

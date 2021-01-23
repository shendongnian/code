    class JsonTester
    {
        public void Test()
        {
            const string json = "{\"MyFeed\":{\"@Provider\":\"SomeProvider\",\"MMM\":{\"@name\":\"3M Corp\",\"low\":\"194.80\",\"high\":\"136.78\",\"change\":\"2.80\",\"pctchange\":\"0.22\",\"ask\":\"135.15\",\"bid_time\":\"20161104131845\",\"bid\":\"134.80\"}}}";
            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyyMMddHHmmss"
            };
            var quoteWrapper = JsonConvert.DeserializeObject<MyFeed>(json, settings);
            var quote = quoteWrapper.Quote;
        }
    }
    public class MyFeed
    {
        [JsonProperty("MyFeed")]
        public Quote Quote { get; set; }
    }
    public class Quote
    {
        [JsonProperty("@Provider")]
        public string Provider { get; set; }
        [JsonProperty(PropertyName = "MMM")]
        public Data Info { get; set; }
    }
    public class Data
    {
        [JsonProperty("@name")]
        public string name { get; set; }
        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal change { get; set; }
        public decimal pctchange { get; set; }
        public decimal ask { get; set; }
        public DateTime bid_time { get; set; }
        public decimal bid { get; set; }
    }

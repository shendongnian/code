    public class CustomersDetails
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }
    public class Data
    {
        public Dictionary<string, CustomersDetails> normal_customer { get; set; }
        public Dictionary<string,CustomersDetails> luxury_customer { get; set; }
    }
    public class RootObject
    {
        public Data data { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("1")]
        public string One { get; set; }
    }
    var root = JsonConvert.DeserializeObject<RootObject>("{'1':'2'}");
    Console.WriteLine(root.One);   // 2

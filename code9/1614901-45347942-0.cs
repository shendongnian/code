    public class MyClass
    {
        public string A { get; set; }
        public string B { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> CS { get; set; }
    }

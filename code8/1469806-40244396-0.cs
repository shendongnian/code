    public class Root
    {
        public string A { get; set; }
        public int B { get; set; }
        [XmlIgnore]
        public Dictionary<string, string> Dict { get; set; }
    }

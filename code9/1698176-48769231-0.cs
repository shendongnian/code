    public class TestJson
    {
        [JsonProperty("m2m:ae")]
        public Class2 Class2Instance { get; set; }    
    
    }
    public class Class2
    {
        public string Api { get; set; }
        public string Rr { get; set; }
        public string[] Lbl { get; set; }
        public string Rn { get; set; }
    }

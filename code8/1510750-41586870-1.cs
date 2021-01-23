	public class First
    {
        [JsonProperty("FirstBool")]
        public int FirstBool { get; set; }
        [JsonProperty("aString")]
        public string aString { get; set; }
    }
    public class Second
    {
        [JsonProperty("AnotherBool")]
        public int AnotherBool { get; set; }
        [JsonProperty("aString")]
        public string aString { get; set; }
    }
    public class Third
    {
        [JsonProperty("ThirdBool")]
        public int ThirdBool { get; set; }
        [JsonProperty("aString")]
        public string aString { get; set; }
        [JsonProperty("AdditionalString")]
        public string AdditionalString { get; set; }
    }
    public class ClsResult
    {
        [JsonProperty("First")]
        public First First { get; set; }
        [JsonProperty("Second")]
        public Second Second { get; set; }
        [JsonProperty("Third")]
        public Third Third { get; set; }
    }

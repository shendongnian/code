    public class RootObject
    {
       [JsonProperty("0")]
        public List<InnerObj> zero { get; set; }
    }
    public class InnerObj
    {
        public string Range { get; set; }
        public string Date { get; set; }
        public string Code { get; set; }
    }

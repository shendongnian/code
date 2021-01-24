    public class Value
    {
        [JsonProperty("@search.score")]
        public double SearchScore { get; set; }
        public string Id { get; set; }
        public string Date { get; set; }
        public string Domain { get; set; }
        public string RuleName { get; set; }
        public string Log { get; set; }
        public string ChangeId { get; set; }
        public string ParentId { get; set; }
        public string Comments { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("@odata.context")]
        public string Contextcontext { get; set; }
        public List<Value> value { get; set; }
    }

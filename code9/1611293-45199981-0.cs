    public class Times
    {
        [JsonProperty("0")]
        public List<TimeObject> times { get; set; }
    }
    public class TimeObject
    {
        public string Range { get; set; }
        public string Date { get; set; }
        public string Code { get; set; }
    }
}

    public class Status
    {
        [JsonProperty("domain")]
        public string name { get; set; }
        [JsonProperty("zone")]
        public string zone { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("summary")]
        public string summary { get; set; }
    }
    public class ClsStatus
    {
        [JsonProperty("status")]
        public List<Status> status { get; set; }
    }

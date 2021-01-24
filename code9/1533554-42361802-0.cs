    public class Result
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("web_id")]
        public string web_id { get; set; }
        [JsonProperty("certificate_id")]
        public string certificate_id { get; set; }
        [JsonProperty("domain")]
        public string domain { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("updated_at")]
        public string updated_at { get; set; }
        [JsonProperty("IP")]
        public string IP { get; set; }
        [JsonProperty("OS_version")]
        public string OS_version { get; set; }
    }
    public class Rootobject
    {
        [JsonProperty("status")]
        public bool status { get; set; }
        [JsonProperty("result")]
        public List<Result> result { get; set; }
        [JsonProperty("errors")]
        public List<object> errors { get; set; }
    }

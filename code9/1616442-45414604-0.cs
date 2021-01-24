    public class Data
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class ReportResponse
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("short_id")]
        public int Short_id { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }
        //public Data Data { get; set; }
    }
    var deserializeReponse = JsonConvert.DeserializeObject<ReportResponse>(rawResponse);

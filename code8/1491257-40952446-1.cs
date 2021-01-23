    public class Record
    {
        [JsonExtensionData]
        public Dictionary<string, object> Data { get; set; }
        [JsonProperty("f_EMail")]
        public string Email { get; set; }
        [JsonProperty("f_FirstName")]
        public string FirstName { get; set; }
        ...
    }

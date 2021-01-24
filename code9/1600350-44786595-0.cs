    [JsonObject]
    public class ApiResponseMessage
    {
        [JsonProperty("$skip")]
        public int Skip { get; set; }
        [JsonProperty("$top")]
        public int Top { get; set; }
        ....
    }

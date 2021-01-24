    public class MyModelClass
    {
        [JsonProperty("first_field")]
        public string FirstField { get; set; }
    
        [JsonProperty("second_field")]
        [JsonConverter(typeof(UrlEncodingConverter))]
        public string SecondField { get; set; }
    }

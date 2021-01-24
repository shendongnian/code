    public class MyModelClass
    {
        [JsonProperty("first_field")]
        public string FirstField { get; set; }
    
        [UrlEncode]
        [JsonProperty("second_field")]
        public string SecondField { get; set; }
        ...
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Result
    {
        [JsonProperty("Success")]
        public bool Success{ get; set; }
        [JsonProperty("Result")]
        public List<JsonCContainer> Items{ get; set; }
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonCContainer
    {
        [JsonProperty("Param1")]
        public string param1{ get; set; }
        [JsonProperty("Param2")]
        public string param2{ get; set; }
        [JsonProperty("Param3")]
        public string param3{ get; set; }
        [JsonProperty("Param5")]
        public string param5{ get; set; }
    }
    public class CContainer
    {
        public string param1{ get; set; }
        public string param2{ get; set; }
        public string param3{ get; set; }
    }

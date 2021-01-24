    public class JsonObject
    {
        public string Address { get; set; }
        [JsonProperty("public")]
        public string PublicKey { get; set; }
        [JsonProperty("private")]
        public string PrivateKey { get; set; }
    }
    var jsonObject = JsonConvert.DeserializeObject<JsonObject>(json);
    //jsonObject.PublicKey

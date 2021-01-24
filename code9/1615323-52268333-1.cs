    [Serializable, JsonObject]
    public class FirebaseIdentity
    {
        [JsonProperty("identities")]
        public Identities identities { get; set; }
        [JsonProperty("sign_in_provider")]
        public string sign_in_provider { get; set; }
    }
    [Serializable, JsonObject]
    public class Identities
    {
        [JsonProperty("email")]
        public List<string> email { get; set; }
    }

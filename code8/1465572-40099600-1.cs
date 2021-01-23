    [JsonObject(MemberSerialization.OptIn)]
    public class AppCard
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Author { get; set; }
        public bool IsInstalled { get; set; }
    }

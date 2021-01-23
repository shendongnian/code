    [JsonObject(ItemRequired = Required.Always)]
    public class AppCard
    {
        public string Name { get; set; }
        public string Author { get; set; }
        [JsonIgnore]
        public bool IsInstalled { get; set; }
    }

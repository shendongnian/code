    public class RootObject
    {
        [JsonProperty("data")]
        public List<Item> Data { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("objCode")]
        public string ObjCode { get; set; }
        [JsonProperty("emailAddr")]
        public string Email { get; set; }
    }

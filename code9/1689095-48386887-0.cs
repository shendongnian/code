    public class Inventory
    {
        public string fourthop { get; set; }
    }
    public class World
    {
        public string secondop { get; set; }
    }
    public class Actions
    {
        public Inventory inventory { get; set; }
        public World world { get; set; }
    }
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool exchangeable { get; set; }
        public bool members { get; set; }
        public int placeholder_id { get; set; }
        [JsonIgnore]//Ignore deserialization
        public Actions actions { get; set; }
    }
    var result = JsonConvert.DeserializeObject<List<RootObject>>(json);

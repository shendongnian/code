    public class Rages
    {
        public string rage_content { get; set; }
        public string date_stamp { get; set; }
        public int id { get; set; }
    }
    
    public class Item
    {
        [JsonProperty(Name="rage_id")]
        public string unique_id { get; set; }
        public Rages rages { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }

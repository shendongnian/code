    [JsonObject]
    public class Entry
    {
        public int value { get; set; }
        public double percent { get; set; }
    }
    [JsonObject]
    public class Item
    {
        public List<Entry> entries { get; set; }
    }

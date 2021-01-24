    public class Page: EntityData
    {
        public int Color { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
        public int Height { get; set; }
        public Point Offset { get; set; }
    }

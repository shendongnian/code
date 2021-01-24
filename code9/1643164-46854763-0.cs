    public class Tree
    {
        [JsonProperty("AND")]
        public Leaf[] And { get; set; } // Could be null
        [JsonProperty("OR")]
        public Leaf[] Or { get; set; } // Could be null
    }
    public struct Leaf
    {
        public string String; // Could be null
        public Top Tree; // Could be null
    }

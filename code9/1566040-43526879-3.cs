    public class PArray
    {
        public IEnumerable<Items> Items { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty(PropertyName = "$pArray")]
        public PArray Root { get; set; }
    }

    public class Configuration
    {
        public int a { get; set; }
        public int b { get; set; }
        public Obj1 obj1 { get; set; }
        // Converts the entire list to a compressed string
        [JsonConverter(typeof(IntListConverter))]
        public int[] c { get; set; }
        // Converts each Obj2 item individually
        [JsonProperty(ItemConverterType = typeof(Obj2Converter))]
        public IList<Obj2> obj2 { get; set; }
    }

    public class Dimension {
        public DimensionDetail aquameth { get; set; }
        public DimensionDetail aquaenv { get; set; }
        public DimensionDetail species { get; set; }
        public DimensionDetail fishreg { get; set; }
        public DimensionDetail unit { get; set; }
        public DimensionDetail geo { get; set; }
        public DimensionDetail time { get; set; }
    }
    
    public class DimensionDetail {
        public string label { get; set; }
        public Category category { get; set; }
    }
    public class Category {
        public Dictionary<string, int> index { get; set; }
        public Dictionary<string, string> label { get; set; }
    }

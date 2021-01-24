    public class Dimension
        {
            public DimensionAquameth aquameth { get; set; }
        }
        public class DimensionAquameth
        {
            public string label { get; set; }
            public DimensionCategory category { get; set; }
        }
        public class DimensionCategory
        {
            public Dictionary<string, string> index { get; set; }
            public Dictionary<string, string> label { get; set; }
        }

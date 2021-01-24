    public class NestedStats
    {
        public string kind { get; set; }
        public string selfLink { get; set; }
    }
    public class Entry
    {
        public NestedStats NestedStats { get; set; }
    }
    public class Root
    {
        public string kind { get; set; }
        public int generation { get; set; }
        public string selfLink { get; set; }
        public Dictionary<string, Entry> entries { get; set; }
    }

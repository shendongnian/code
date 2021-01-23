    public class SubItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public string Description { get; set; }
    }
    public class Output
    {
        public string Name { get; set; }
        public bool Required { get; set; }
    }
    public class JsonObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<SubItem> SubItems { get; set; }
        public List<Output> Outputs { get; set; }
    }

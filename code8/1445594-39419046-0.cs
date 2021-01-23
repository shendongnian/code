    public class SubItem
    {
        public string name { get; set; }
        public bool required { get; set; }
        public string description { get; set; }
    }
    public class Output
    {
        public string name { get; set; }
        public bool required { get; set; }
    }
    public class JsonObject
    {
        public string name { get; set; }
        public string description { get; set; }
        public string Location { get; set; }
        public List<SubItem> SubItems { get; set; }
        public List<Output> outputs { get; set; }
    }

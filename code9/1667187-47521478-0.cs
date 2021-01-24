    public class Extension {
        public string datasetId { get; set; }
        public string lang { get; set; }
        public string description { get; set; }
        public string subTitle { get; set; }
        public ExtensionStatus status { get; set; }
    }
    public class ExtensionStatus {
        public Dictionary<string, string> label { get; set; }
    }

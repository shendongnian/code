    public class RootObject
    {
        public double currentVersion { get; set; }
        public string serviceDescription { get; set; }
        public bool hasVersionedData { get; set; }
        public bool supportsDisconnectedEditing { get; set; }
        public bool syncEnabled { get; set; }
        public string supportedQueryFormats { get; set; }
        public int maxRecordCount { get; set; }
    }

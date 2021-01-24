    public class FileAttributes {
        [JsonProperty("SYSTEM.NAME")]
        public string Name { get; set; }
        [JsonProperty("SYSTEM.HEADER")]
        public string Header { get; set; }
        [JsonProperty("SYSTEM.TITLE")]
        public string Title { get; set; }
    }
    public class RootObject {
        public IList<FileAttributes> SearchData { get; set; }
    }

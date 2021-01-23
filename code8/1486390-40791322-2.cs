    public class Files
    {
        [XmlElement("File")]
        public File[] File { get; set; }
    }
    public class File
    {
        public string Type { get; set; }
        public string FileName { get; set; }
        public int Port { get; set; }
        public string FileLocation { get; set; }
    }

    public class Attachment
    {
        public string FileName { get; set; }
    
        [XmlIgnore]
        public StorageFile File { get; set; }
    
        public Boolean UserCreatedContent { get; set; }
    }

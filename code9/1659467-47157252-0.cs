    [Serializable]
    public class Document
    {
        [DataMember]
        public string FileURL { get; set; }
    
        [IgnoredDataMember]
        public string FileSize { get; set; }
    }

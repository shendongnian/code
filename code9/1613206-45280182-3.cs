    [XmlRoot(ElementName = "FileInfo")]
    public class FileInfo
    {
        [XmlAttribute(AttributeName = "NumberOfEntries")]
        public string NumberOfEntries { get; set; }
        [XmlAttribute(AttributeName = "FileCreationTime")]
        public string FileCreationTime { get; set; }
    }
    [XmlRoot(ElementName = "LanguageEntry")]
    public class LanguageEntry
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "Mark")]
        public string Mark { get; set; }
    }
    [XmlRoot(ElementName = "Entry")]
    public class Entry
    {
        [XmlElement(ElementName = "LanguageEntry")]
        public List<LanguageEntry> LanguageEntry { get; set; }
        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; set; }
        [XmlAttribute(AttributeName = "CreationTime")]
        public string CreationTime { get; set; }
        [XmlAttribute(AttributeName = "LastModifiedTime")]
        public string LastModifiedTime { get; set; }
    }
    [XmlRoot(ElementName = "Language")]
    public class Language
    {
        [XmlElement(ElementName = "FileInfo")]
        public FileInfo FileInfo { get; set; }
        [XmlElement(ElementName = "Entry")]
        public Entry Entry { get; set; }
    }

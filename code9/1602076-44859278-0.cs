    [XmlRoot("old-root")]
    public class Root
    {
        [XmlIgnore]
        public Dictionary<string, string> Contacts { get; set; }
    }

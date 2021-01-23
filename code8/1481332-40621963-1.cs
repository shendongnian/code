    [Serializable]
    public class MyType
    {
        [XmlElement("MyProperty1")
        public string MyProperty1 { get; set; }
    
        [XmlElement("MyProperty2")
        public string MyProperty2 { get; set; }
    
        [XmlElement("MyNestedXml")]
        public RichText MyNestedXml { get; set; }
    }

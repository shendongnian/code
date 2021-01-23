    [XmlRoot("MyType")]
    public class MyType
    {
        [XmlElement("MyProperty1")]
        public string MyProperty1 { get; set; }
        [XmlElement("MyProperty2")]
        public string MyProperty2 { get; set; }
        [XmlAnyElement("MyNestedXml")]
        public XmlElement MyNestedXml { get; set; }
    }

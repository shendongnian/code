    [XmlRoot(ElementName = "Message", Namespace = "//namespaceforxml")]
    public class Message
    {
        [XmlElement(ElementName = "val1")]
        public string val1{ get; set; }
    }

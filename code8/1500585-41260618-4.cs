    [XmlRoot(ElementName = "processAcord", Namespace = "http://ws.plus.predictivelogic.com/")]
    [XmlSerializerFormat]  // tell WCF to not to use the DataContractSerializer
    public class Input
    {
        [XmlElement(ElementName = "arg0", Namespace = "")]
        public string Arg0 { get; set; }
        [XmlElement(ElementName = "arg1", Namespace = "")]
        public string Arg1 { get; set; }
        [XmlElement(ElementName = "arg2", Namespace = "")]
        public string Arg2 { get; set; }
        [XmlElement(ElementName = "arg3", Namespace = "")]
        public string Arg3 { get; set; }
        [XmlAttribute(AttributeName = "ws", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ws { get; set; }
    }

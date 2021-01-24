    [Serializable,XmlRoot("Status", Namespace="DistributionServices")]
    public class MessageData
    {
        [XmlElement("Server")]
        public string Server { get; set; }
    
        [XmlElement("Object")]
        public string Object { get; set; }
    
        [XmlElement("Port")]
        public string Port { get; set; }
    
        [XmlElement("Code")]
        public string Code { get; set; }
    
        [XmlElement("Key")]
        public string Key { get; set; }
    }

    [Serializable, XmlRoot("Status", Namespace = "DistributionServices")]
    public class MessageData
    {
        [XmlElement(Namespace = "")]
        public string Server { get; set; }
        [XmlElement(Namespace = "")]
        public string Object { get; set; }
        [XmlElement(Namespace = "")]
        public string Port { get; set; }
        [XmlElement(Namespace = "")]
        public string Code { get; set; }
        [XmlElement(Namespace = "")]
        public string Key { get; set; }
    }

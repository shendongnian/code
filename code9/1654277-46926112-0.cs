    [XmlRoot(ElementName = "Device")]
    public class Device
    {
        [XmlAttribute(AttributeName = "TB")]
        public string TB { get; set; }
        [XmlAttribute(AttributeName = "properties")]
        public string Properties { get; set; }
    }
    
    [XmlRoot(ElementName = "PortA")]
    public class PortA
    {
        [XmlElement(ElementName = "Device")]
        public Device Device { get; set; }
        [XmlAttribute(AttributeName = "Connected_BY")]
        public string Connected_BY { get; set; }
    }
    
    [XmlRoot(ElementName = "PortB")]
    public class PortB
    {
        [XmlAttribute(AttributeName = "Connected_BY")]
        public string Connected_BY { get; set; }
    }
    
    [XmlRoot(ElementName = "PortE")]
    public class PortE
    {
        [XmlElement(ElementName = "Device")]
        public Device Device { get; set; }
        [XmlAttribute(AttributeName = "Connected_BY")]
        public string Connected_BY { get; set; }
    }
    
    [XmlRoot(ElementName = "CMS")]
    public class CMS
    {
        [XmlElement(ElementName = "Device")]
        public Device Device { get; set; }
    }

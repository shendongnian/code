    [XmlRoot(ElementName = "Parent", Namespace = "http://main.com")]
    public class Parent
    {
        [XmlElement(ElementName = "Child")]
        public Child Child{ get; set; }
    }
    
    [XmlType(Namespace = "http://main.com")]
    public class Child
    {
        [XmlAttribute(AttributeName = "value", Namespace = "http://sub.com")]
        public string Value { get; set; }
    }

    [XmlRoot("Parent")]
    public class MyElement
    {
        [XmlElement(typeof(ChildElementA))]
        [XmlElement(typeof(ChildElementB))]
        public BaseChildElement[] MyChildren { get; set; }
    }
    public abstract class BaseChildElement { }
    [XmlType("ChildTypeA")]
    public class ChildElementA : BaseChildElement
    {
        [XmlAttribute]
        public string Content { get; set; }
    }
    [XmlType("ChildTypeB")]
    public class ChildElementB : BaseChildElement
    {
        [XmlAttribute]
        public string BContent { get; set; }
    }

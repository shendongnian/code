    public class mainelement
    {
        [XmlElement(Namespace = "http://example.com/xml")]
        public subelement subelement { get; set; }
    }
    
    public class subelement
    {
        [XmlAttribute]
        public string otherAttr { get; set; }    
    }

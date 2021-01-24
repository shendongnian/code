    public enum DateType
    {
        Foo, Bar, Baz
    }
    
    [XmlRoot(ElementName = "date")]
    public class Date
    {
        [XmlAttribute(AttributeName = "type")]
        public DateType Type { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
    
    [XmlRoot(ElementName = "offer")]
    public class Offer
    {
        [XmlElement(ElementName = "date")]
        public Date[] Dates { get; set; }
    }

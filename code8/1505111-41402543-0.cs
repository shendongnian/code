    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot("delivery")]
    public class Delivery
    {
        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }
        [XmlAttribute(AttributeName = "amount")]
        public string Amount { get; set; }
        public Delivery()
        { }
    } 

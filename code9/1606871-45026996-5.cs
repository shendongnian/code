    [XmlType("item")]
    public class Item 
    {
        [XmlElement(ElementName = "sku")]
        public string sku { get; set; }
        [XmlElement(ElementName = "style")]
        public string style { get; set; }
        [XmlElement(ElementName = "reason")]
        public string reason { get; set; }
    }

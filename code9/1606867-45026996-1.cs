    [XmlType("item")]
    public class Item 
    {
        [XmlElement(ElementName = "sku")]
        string sku { get; set; }
        [XmlElement(ElementName = "style")]
        string style { get; set; }
        [XmlElement(ElementName = "reason")]
        string reason { get; set; }
    }

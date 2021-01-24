    [XmlRoot("orderMessage", Namespace = "urn:gs1:ecom:order:xsd:3")]
    public class OrderMessage
    {
        [XmlElement("order", Namespace = "")]
        public List<Order> Orders { get; set; }
    }
    
    public class Order
    {
        [XmlElement("creationDateTime")]
        public string CreationDateTime { get; set; }
    
        [XmlElement("documentStatusCode")]
        public string DocumentStatusCode { get; set; }
    
        [XmlElement("documentActionCode")]
        public string DocumentActionCode { get; set; }
    }

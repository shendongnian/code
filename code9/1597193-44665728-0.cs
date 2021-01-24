    [XmlRoot(ElementName = "Customer", Namespace = "http://myNameSpace.Customer")]
    public class Customer
    {
        [XmlElement(ElementName = "Company", Namespace = "")]
        public string Company { get; set; }
        [XmlElement(ElementName = "Division", Namespace = "")]
        public string Division { get; set; }
    }

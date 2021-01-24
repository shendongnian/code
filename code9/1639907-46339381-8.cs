    [XmlRoot(ElementName = "Cargo")]
    public class Cargo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "AddedService")]
    public class AddedService
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "Order")]
    public class Order
    {
        [XmlElement(ElementName = "Cargo")]
        public List<Cargo> Cargo { get; set; }
        [XmlElement(ElementName = "AddedService")]
        public List<AddedService> AddedService { get; set; }
        [XmlAttribute(AttributeName = "pay_method")]
        public string Pay_method { get; set; }
        [XmlAttribute(AttributeName = "custid")]
        public string Custid { get; set; }
    }

    [XmlType("entity")]
    public class Order
    {
        public long id { get; set; }
        public string ordernumber { get; set; }
        [XmlAnyElement]
        public XmlElement audits { get; set; }
    }

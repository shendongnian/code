    [XmlRoot("e-Invoice")]
    public class EInvoice : Invoice
    {
        [XmlElement("Version")]
        public string Version { get; set; }
    }
    [XmlRoot("TradeInvoice")]
    public class TradeInvoice : Invoice
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Value")]
        public int Value { get; set; }
    }

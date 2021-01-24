    [XmlRoot("RootXML")]
    public class Root
    {
        public Root()
        {
            RootBodies = new List<Invoice>();
        }
        [XmlElement(Type = typeof(EInvoice), ElementName = "e-Invoice")]
        [XmlElement(Type = typeof(TradeInvoice), ElementName = "TradeInvoice")]
        public List<Invoice> RootBodies { get; set; }
    }

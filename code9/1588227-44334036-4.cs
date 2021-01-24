    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        public Body Body { get; set; }
    }
    public class Body
    {
        [XmlElement("getPreSubmitInfoResponse", Namespace = "http://webservice.integration.someservice.com/")]
        public GetPreSubmitInfoResponse GetPreSubmitInfoResponse { get; set; }
    }
    [XmlRoot("getPreSubmitInfoResponse")]
    public class GetPreSubmitInfoResponse
    {
        [XmlElement("return", Namespace = "")]
        public Return Return { get; set; }
    }
    [XmlRoot("return")]
    public class Return
    {
        [XmlElement("errorOccurred")]
        public bool ErrorOccurred { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
        [XmlElement("response")]
        public Response Response { get; set; }
    }
    [XmlRoot("response", Namespace = "")]
    [XmlInclude(typeof(webServicePO))]
    public class Response
    {
        [XmlElement("internalMessage")]
        public string InternalMessage { get; set; }
        [XmlElement("poNum")]
        public ushort PoNum { get; set; }
        [XmlElement("residence")]
        public string Residence { get; set; }
        [XmlElement("shipAddress1")]
        public string ShipAddress1 { get; set; }
        [XmlElement("shipAddress2")]
        public object ShipAddress2 { get; set; }
        [XmlElement("shipCity")]
        public string ShipCity { get; set; }
        [XmlElement("shipMethod")]
        public string ShipMethod { get; set; }
        [XmlElement("shipState")]
        public string ShipState { get; set; }
        [XmlElement("shipTo")]
        public string ShipTo { get; set; }
        [XmlElement("shipZip")]
        public uint ShipZip { get; set; }
        [XmlElement("webServicePoDetailList")]
        public WebServicePoDetailList WebServicePoDetailList { get; set; }
    }
    [XmlRoot("webServicePoDetailList", Namespace = "")]
    public class WebServicePoDetailList
    {
        [XmlElement("color")]
        public string Color { get; set; }
        [XmlElement("errorOccured")]
        public bool ErrorOccured { get; set; }
        [XmlElement("inventoryKey")]
        public string InventoryKey { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
        [XmlElement("quantity")]
        public byte Quantity { get; set; }
        [XmlElement("size")]
        public string Size { get; set; }
        [XmlElement("sizeIndex")]
        public byte SizeIndex { get; set; }
        [XmlElement("style")]
        public string Style { get; set; }
        [XmlElement("whseNo")]
        public byte WhseNo { get; set; }
    }
    [XmlRoot("webServicePO", Namespace = "http://webservice.integration.someservice.com/")]
    public class webServicePO : Response { }

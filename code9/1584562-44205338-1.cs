    [XmlRoot(ElementName = "RESPUESTA", Namespace = "http://www.sii.cl/XMLSchema")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "RESP_HDR", Namespace = "http://www.sii.cl/XMLSchema")]
        public RESP_HDR RESP_HDR { get; set; }
        [XmlElement(ElementName = "RESP_BODY", Namespace = "http://www.sii.cl/XMLSchema")]
        public RESP_BODY RESP_BODY { get; set; }
        [XmlAttribute(AttributeName = "SII", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string SII { get; set; }
    }
    public class RESP_HDR { }
    public class RESP_BODY { }

    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope<THeader, TBody>
    where THeader : IEnvelopeHeader where TBody : class, IEnvelopeBody, new()
    {
        [XmlElement(ElementName = "Header", Order = 1)]
        public THeader Header { get; set; }
        [XmlElement(ElementName = "Body", Order = 2)]
        public TBody Body { get; set; }
    }
 
    

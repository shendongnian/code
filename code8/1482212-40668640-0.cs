    [XmlRoot(ElementName = "InfoBasica")]
    public class InfoBasica
    {
        [XmlAttribute(AttributeName = "folio")]
        public string Folio { get; set; }
    }
    [XmlRoot(ElementName = "Emisor")]
    public class Emisor
    {
        [XmlAttribute(AttributeName = "telefono")]
        public string Telefono { get; set; }
    }
    [XmlRoot(ElementName = "Receptor")]
    public class Receptor
    {
        [XmlAttribute(AttributeName = "telefono")]
        public string Telefono { get; set; }
    }
    [XmlRoot(ElementName = "TipoDocumento")]
    public class TipoDocumento
    {
        [XmlAttribute(AttributeName = "nombreCorto")]
        public string NombreCorto { get; set; }
    }
    [XmlRoot(ElementName = "AddendaBuzonFiscal")]
    public class AddendaBuzonFiscal
    {
        [XmlElement(ElementName = "Emisor")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "TipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "ns", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns { get; set; }
    }
    [XmlRoot(ElementName = "Addenda")]
    public class Addenda
    {
        [XmlElement(ElementName = "AddendaBuzonFiscal", Namespace = "http://www.buzonfiscal.com/ns/addenda/bf/2")]
        public AddendaBuzonFiscal AddendaBuzonFiscal { get; set; }
    }
    [XmlRoot(ElementName = "Remision", Namespace = "http://www.buzonfiscal.com/ns/xsd/bf/remision/52")]
    public class Remision
    {
        [XmlElement(ElementName = "InfoBasica")]
        public InfoBasica InfoBasica { get; set; }
        [XmlElement(ElementName = "Addenda")]
        public Addenda Addenda { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

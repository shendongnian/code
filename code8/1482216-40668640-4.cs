    public abstract class XmlSerializationBase : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return default(XmlSchema);
        }
        public virtual void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public virtual void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
    public class InfoBasica
    {
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
    [XmlRoot(ElementName = "AddendaBuzonFiscal", Namespace = "http://www.buzonfiscal.com/ns/addenda/bf/2")]
    public class AddendaBuzonFiscal
    {
        [XmlElement(ElementName = "Emisor", Namespace = "http://www.buzonfiscal.com/ns/addenda/bf/2")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor", Namespace = "http://www.buzonfiscal.com/ns/addenda/bf/2")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "TipoDocumento", Namespace = "http://www.buzonfiscal.com/ns/addenda/bf/2")]
        public TipoDocumento TipoDocumento { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
    public class Addenda : XmlSerializationBase
    {
        public AddendaBuzonFiscal AddendaBuzonFiscal { get; set; }
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Addenda");
            var serializer = new XmlSerializer(typeof(AddendaBuzonFiscal));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns", "http://www.buzonfiscal.com/ns/addenda/bf/2");
            serializer.Serialize(writer, AddendaBuzonFiscal, namespaces);
            writer.WriteEndElement();
        }
    }
    public class Remision : XmlSerializationBase
    {
        public InfoBasica InfoBasica { get; set; }
        public Addenda Addenda { get; set; }
        public string Version { get; set; }
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Remision", "http://www.buzonfiscal.com/ns/xsd/bf/remision/52");
            writer.WriteAttributeString("version", Version);
            writer.WriteStartElement("InfoBasica");
            writer.WriteAttributeString("folio", InfoBasica.Folio);
            writer.WriteEndElement();
            Addenda.WriteXml(writer);
            writer.WriteEndElement();
        }
    }

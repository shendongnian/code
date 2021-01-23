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
    public class Emisor
    {
        public string Telefono { get; set; }
    }
    public class Receptor
    {
        public string Telefono { get; set; }
    }
    public class TipoDocumento
    {
        public string NombreCorto { get; set; }
    }
    public class AddendaBuzonFiscal : XmlSerializationBase
    {
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Version { get; set; }
        public string Ns { get; set; }
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ns", "AddendaBuzonFiscal", Ns);
            writer.WriteAttributeString("version", Version);
            writer.WriteStartElement("ns", "Emisor", Ns);
            writer.WriteAttributeString("telefono", Emisor.Telefono);
            writer.WriteEndElement();
            writer.WriteStartElement("ns", "Receptor", Ns);
            writer.WriteAttributeString("telefono", Emisor.Telefono);
            writer.WriteEndElement();
            writer.WriteStartElement("ns", "TipoDocumento", Ns);
            writer.WriteAttributeString("nombreCorto", Emisor.Telefono);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
    public class Addenda
    {
        public AddendaBuzonFiscal AddendaBuzonFiscal { get; set; }
    }
    public class Remision : XmlSerializationBase
    {
        public InfoBasica InfoBasica { get; set; }
        public Addenda Addenda { get; set; }
        public string Version { get; set; }
        public string Ns { get; set; }
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Remision", Ns);
            writer.WriteAttributeString("version", Version);
            writer.WriteStartElement("InfoBasica");
            writer.WriteAttributeString("folio", InfoBasica.Folio);
            writer.WriteEndElement();
            writer.WriteStartElement("Addenda");
            Addenda.AddendaBuzonFiscal.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }

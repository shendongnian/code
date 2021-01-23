    public class RichText : IXmlSerializable
    {
        public string Raw { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            Raw = reader.ReadInnerXml();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Raw);
        }
    }

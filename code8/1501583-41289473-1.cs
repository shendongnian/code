    public class PhoneNumber : IXmlSerializable
    {
        public string Type { get; set; }
        public string Number { get; set; }
        
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (!reader.IsStartElement())
                reader.Read();
            Type = reader.Name;
            Number = reader.ReadElementContentAsString();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(Type);
            writer.WriteString(Number);
            writer.WriteEndElement();
        }
    }

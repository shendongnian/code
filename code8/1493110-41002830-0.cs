    public class ChildEntity : IXmlSerializable
    {
        public string Name { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            Name = reader.GetAttribute("Name");
            reader.Skip(); // Consume the <ChildEntity> and </ChildEntity> (if present) nodes and everything contained therein.
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
        }
    }

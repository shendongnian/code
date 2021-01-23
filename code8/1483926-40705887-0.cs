    [XmlRoot("Foo")]
    public class Foo : List<int>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadToFollowing("Bar");
            while (reader.Name == "Bar")
                this.Add(reader.ReadElementContentAsInt());
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var n in this)
                writer.WriteElementString("Bar", n.ToString());
        }
    }

    public class MyClass : IXmlSerializable
    {
        public int A { get; set; }
        public int B { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            var element = (XElement)XNode.ReadFrom(reader);
            this.A = (int)element.Attribute("A");
            this.B = (int)element.Attribute("B");
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("A", XmlConvert.ToString(this.A));
            writer.WriteAttributeString("B", XmlConvert.ToString(this.B));
        }
    }

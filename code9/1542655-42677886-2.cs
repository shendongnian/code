    public class MyClass : IXmlSerializable
    {
        public int A { get; set; }
        public int B { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        protected virtual void ReadXmlSubtree(XmlReader reader)
        {
            this.A = XmlConvert.ToInt32(reader.GetAttribute("A"));
            this.B = XmlConvert.ToInt32(reader.GetAttribute("B"));
        }
        public void ReadXml(XmlReader reader)
        {
            // Consume all child nodes of the current element using ReadSubtree()
            using (var subReader = reader.ReadSubtree())
            {
                subReader.MoveToContent();
                ReadXmlSubtree(subReader);
            }
            reader.Read(); // Consume the end element itself.
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("A", XmlConvert.ToString(this.A));
            writer.WriteAttributeString("B", XmlConvert.ToString(this.B));
        }
    }

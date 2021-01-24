    public class CustomXmlTextWriter : XmlTextWriter
    {
        public CustomXmlTextWriter(string fileName)
            : base(fileName, Encoding.UTF8)
        {
            this.Formatting = Formatting.Indented;
        }
        public override void WriteEndElement()
        {
            this.WriteFullEndElement();
        }
    }

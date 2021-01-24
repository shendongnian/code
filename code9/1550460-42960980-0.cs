    public class FullElementXmlTextWriter : XmlTextWriter
    {
        public FullElementXmlTextWriter(TextWriter w) : base(w) { }
        public FullElementXmlTextWriter(Stream w, Encoding encoding) : base(w, encoding) { }
        public FullElementXmlTextWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }

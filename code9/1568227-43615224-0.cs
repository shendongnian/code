    public class DataClassWriter : XmlTextWriter
    {
        public DataClassWriter(string url) : base(url, Encoding.UTF8) { }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (localName.StartsWith("Field"))
            {
                base.WriteStartElement(prefix, localName, ns);
                base.WriteAttributeString("code", "code#" + localName.Substring(5));
            }
            else
                base.WriteStartElement(prefix, localName, ns);
        }
    }

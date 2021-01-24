    public class CustomXmlReader : XmlTextReader
    {
        // Define other required constructors
        public CustomXmlReader(string url) : base(url) { }
        public CustomXmlReader(TextReader reader) : base(reader) { }
        public override string NamespaceURI
        {
            get
            {
                if (base.NamespaceURI == "order")
                    return "customer";
                return base.NamespaceURI;
            }
        }
    }

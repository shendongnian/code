    public class FixingXmlTextReader : XmlTextReader
    {
        public override string NamespaceURI
        {
            get
            {
                if (NodeType == XmlNodeType.Attribute && base.NamespaceURI == string.Empty && base.LocalName == "noNamespaceSchemaLocation")
                {
                    return "http://www.w3.org/2001/XMLSchema-instance";
                }
                return base.NamespaceURI;
            }
        }
        public override string Prefix
        {
            get
            {
                if (NodeType == XmlNodeType.Attribute && base.NamespaceURI == string.Empty && base.LocalName == "noNamespaceSchemaLocation")
                {
                    return "xsi";
                }
                return base.Prefix;
            }
        }
        public override string Name
        {
            get
            {
                if (NodeType == XmlNodeType.Attribute && base.NamespaceURI == string.Empty && base.LocalName == "noNamespaceSchemaLocation")
                {
                    return NameTable.Add(Prefix + ":" + LocalName);
                }
                return base.Name;
            }
        }
        public override string GetAttribute(string localName, string namespaceURI)
        {
            if (localName == "noNamespaceSchemaLocation" && namespaceURI == "http://www.w3.org/2001/XMLSchema-instance")
            {
                namespaceURI = string.Empty;
            }
            return base.GetAttribute(localName, namespaceURI);
        }
        public override string GetAttribute(string name)
        {
            if (name == "xsi:noNamespaceSchemaLocation")
            {
                name = "noNamespaceSchemaLocation";
            }
            return base.GetAttribute(name);
        }
        // There are tons of constructors, take the ones you need
        public FixingXmlTextReader(Stream stream) : base(stream)
        {
        }
        public FixingXmlTextReader(TextReader input) : base(input)
        {
        }
        public FixingXmlTextReader(string url) : base(url)
        {
        }
    }

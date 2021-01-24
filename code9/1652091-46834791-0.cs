    public class CustomXmlReader : XmlTextReader
    {
        public CustomXmlReader(string url) : base(url) { }
        public override string GetAttribute(string localName, string namespaceURI)
        {
            if (namespaceURI == "http://www.w3.org/2001/XMLSchema-instance" && localName == "type")
            {
                if (base.LocalName == "Child")
                {
                    var attr = base.GetAttribute("AttribName");
                    if (attr == "TypeOne")
                        return "Child1";
                    if (attr == "TypeTwo")
                        return "Child2";
                }
            }
            return base.GetAttribute(localName, namespaceURI);
        }
    }

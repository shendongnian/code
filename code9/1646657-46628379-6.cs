    public static partial class XmlReaderExtensions
    {
        public static IEnumerable<XElement> WalkXmlElements(this XmlReader xmlReader, Predicate<Stack<XName>> filter)
        {
            Stack<XName> names = new Stack<XName>();
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    names.Push(XName.Get(xmlReader.LocalName, xmlReader.NamespaceURI));
                    if (filter(names))
                    {
                        using (var subReader = xmlReader.ReadSubtree())
                        {
                            yield return XElement.Load(subReader);
                        }
                    }
                }
                if ((xmlReader.NodeType == XmlNodeType.Element && xmlReader.IsEmptyElement)
                    || xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    names.Pop();
                }
            }
        }
    }

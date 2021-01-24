    public static class XmlReaderExtensions
    {
        public static IEnumerable<IEnumerable<XElement>> ReadNestedElements(this XmlReader xmlReader, string outerName, string innerName)
        {
            while (!xmlReader.EOF)
            {
                if (xmlReader.NodeType == System.Xml.XmlNodeType.Element && xmlReader.Name == outerName)
                {
                    using (var subReader = xmlReader.ReadSubtree())
                    {
                        yield return subReader.ReadElements(innerName);
                    }
                }
                xmlReader.Read();
            }
        }
        public static IEnumerable<XElement> ReadElements(this XmlReader xmlReader, string name)
        {
            while (!xmlReader.EOF)
            {
                if (xmlReader.NodeType == System.Xml.XmlNodeType.Element && xmlReader.Name == name)
                {
                    var element = (XElement)XNode.ReadFrom(xmlReader);
                    yield return element;
                }
                else
                {
                    xmlReader.Read();
                }
            }
        }
    }

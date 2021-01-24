    public class MyCollection : System.Collections.Generic.Dictionary<string, string>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            using (var subReader = reader.ReadSubtree())
            {
                XmlKeyValueListHelper.ReadKeyValueXml(subReader, this);
            }
            // Consume the EndElement also (or move past the current element if reader.IsEmptyElement).
            reader.Read();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlKeyValueListHelper.WriteKeyValueXml(writer, this);
        }
    }
    public static class XmlKeyValueListHelper
    {
        private const string XmlElementName = "MyData";
        private const string XmlAttributeId = "Id";
        public static void WriteKeyValueXml(System.Xml.XmlWriter writer, ICollection<KeyValuePair<string, string>> collection)
        {
            foreach (var pair in collection)
            {
                writer.WriteStartElement(XmlElementName);
                writer.WriteAttributeString(XmlAttributeId, pair.Key);
                writer.WriteString(pair.Value);
                writer.WriteEndElement();
            }
        }
        public static void ReadKeyValueXml(System.Xml.XmlReader reader, ICollection<KeyValuePair<string, string>> collection)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            reader.ReadStartElement(); // Advance to the first sub element of the list element.
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == XmlElementName)
                {
                    var tag = reader.GetAttribute(XmlAttributeId);
                    string content;
                    if (reader.IsEmptyElement)
                    {
                        content = string.Empty;
                        // Move past the end of item element
                        reader.Read();
                    }
                    else
                    {
                        // Read content and move past the end of item element
                        content = reader.ReadElementContentAsString();
                    }
                    collection.Add(new KeyValuePair<string, string>(tag, content));
                }
                else
                {
                    // For instance a comment.
                    reader.Skip();
                }
            }
            // Move past the end of the list element
            reader.ReadEndElement();
        }
    }

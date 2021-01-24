    public static class XmlReaderExtensions
    {
        public static IEnumerable<TElement> DeserializeSequence<TElement>(this XmlReader reader, string localEntityElementName, string namespaceURI)
        {
            if (reader == null)
                throw new ArgumentNullException();
            var deserializer = new XmlSerializer(typeof(TElement));
            while ((reader.NodeType == XmlNodeType.Element && reader.LocalName == localEntityElementName && reader.NamespaceURI == namespaceURI)
                || reader.ReadToNextSibling(localEntityElementName, namespaceURI))
            {
                // Using ReadSubtree instead of ReadOuterXml() avoids having do parse, reformat, then parse the formatted XML a second time
                // by reading directly from the current stream only once.
                TElement element;
                using (var subReader = reader.ReadSubtree())
                {
                    element = (TElement)deserializer.Deserialize(subReader);
                }
                // Consume the EndElement also (or move past the current element if reader.IsEmptyElement).
                reader.Read();
                yield return element;
            }
        }
    }

    public static class XmlNodeExtensions
    {
        public static XmlNode ReplaceWithSerializationOf<T>(this XmlNode node, T replacement)
        {
            if (node == null)
                throw new ArgumentNullException();
            var parent = node.ParentNode;
            var serializer = new XmlSerializer(replacement == null ? typeof(T) : replacement.GetType());
            using (var writer = node.CreateNavigator().InsertAfter())
            {
                // WriteWhitespace needed to avoid error "WriteStartDocument cannot
                // be called on writers created with ConformanceLevel.Fragment."
                writer.WriteWhitespace("");
                // Set up an appropriate initial namespace.
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(node.GetNamespaceOfPrefix(node.NamespaceURI), node.NamespaceURI);
                // Serialize
                serializer.Serialize(writer, replacement, ns);
            }
            var nextNode = node.NextSibling;
            parent.RemoveChild(node);
            return nextNode;
        }
    }

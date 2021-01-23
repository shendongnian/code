        private void DeserializeValue(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, string propertyName, IXmlNode currentNode)
        {
            switch (propertyName)
            {
                case TextName:
                    currentNode.AppendChild(document.CreateTextNode(reader.Value.ToString()));
                    break;
    As you can see, the conversion logic is missing and `ToString()` is used instead.  That's the bug.

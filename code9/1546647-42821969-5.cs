    private static string SerializeByLinqAndToString<T>(
        List<T> data, string rootName, string elementName)
    {
        XDocument document = new XDocument(
            new XElement(rootName, data.Select(s => new XElement(elementName, s))));
        return SaveXmlToString(document);
    }
    private static string SaveXmlToString(XDocument document)
    {
        StringBuilder sb = new StringBuilder();
        using (XmlWriter xmlWriter = XmlWriter.Create(sb,
            new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
        {
            document.Save(xmlWriter);
        }
        return sb.ToString();
    }

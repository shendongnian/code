    private static string SerializeByLinq<T>(
        List<T> data, string rootName, string elementName = null)
    {
        XDocument document = new XDocument(
            new XElement(rootName, data.Select(t =>
                ElementFromText(SerializeObject(t), elementName)
            )));
        return SaveXmlToString(document);
    }
    private static XElement ElementFromText(string xml, string name = null)
    {
        StringReader reader = new StringReader(xml);
        XElement result = XElement.Load(reader);
        if (!string.IsNullOrEmpty(name))
        {
            result.Name = name;
        }
        return result;
    }
    private static string SerializeObject<T>(T o)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringWriter textWriter = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(textWriter,
            new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
        {
            xmlSerializer.Serialize(writer, o,
                new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty}));
        }
        return textWriter.ToString();
    }

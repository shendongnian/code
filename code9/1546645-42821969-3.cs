    private static string SerializeByLinq<T>(List<T> data, string rootName)
    {
        XDocument document = new XDocument(
            new XElement(rootName, data.Select(t => Serialize(t))));
        StringWriter writer = new StringWriter();
        document.Save(writer);
        string xmlText = writer.ToString();
        xmlText = xmlText.Replace("&lt;", "<");
        xmlText = xmlText.Replace("&gt;", ">");
        xmlText = xmlText.Substring(xmlText.IndexOf($"<{rootName}>"));
        XDocument doc = XDocument.Parse(xmlText);
        return doc.ToString();
    }
    private static string Serialize<T>(T toSerialize)
    {
        var xmlSerializer = new System.Xml.Serialization.XmlSerializer(toSerialize.GetType());
        string result;
        var textWriter = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(textWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
        {
            xmlSerializer.Serialize(writer, toSerialize, new System.Xml.Serialization.XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
            result = textWriter.ToString();
        }
        return result;
    }

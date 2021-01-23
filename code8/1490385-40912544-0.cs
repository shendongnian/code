    public static string XmlSerialize<T>(T data)
    {
    string result;
    using (StringWriter stringWriter = new StringWriter())
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Encoding = Encoding.UTF8,
            OmitXmlDeclaration = true,
        };
        using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
            serializer.Serialize(writer, data, ns);
            if (writer != null)
                writer.Dispose();
        }
        result = stringWriter.ToString();
        if (stringWriter != null)
            stringWriter.Dispose();
    }
    
    return result;
    }

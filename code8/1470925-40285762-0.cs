    var doc = new XDocument(new XElement("root"));
    byte[] bytes;
    var isoEncoding = Encoding.GetEncoding("ISO-8859-1");
    var settings = new XmlWriterSettings
    {
        Indent = true,
        Encoding = isoEncoding
    };
    using (var ms = new MemoryStream())
    {
        using (var writer = XmlWriter.Create(ms, settings))
        {
            doc.Save(writer);
        }
        bytes = ms.ToArray();
    }

    var settings = new XmlWriterSettings
    {
        OmitXmlDeclaration = true,
        NewLineChars = "\n"
    };
    string xmlString;
    using (var sw = new StringWriter())
    {
        using (var xw = XmlWriter.Create(sw, settings))
        {
            doc.Root.WriteTo(xw);                    
        }
        xmlString = sw.ToString();
    }

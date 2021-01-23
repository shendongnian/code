    var settings = new XmlWriterSettings
    {
        OmitXmlDeclaration = true,        
        NewLineHandling =  NewLineHandling.None
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

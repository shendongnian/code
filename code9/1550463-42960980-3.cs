    string xmltext;
    using (var stringWriter = new StringWriter())
    {
        using (var innerXmlWriter = XmlWriter.Create(stringWriter, settings))
        using (var xmlTextWriter = new FullElementXmlWriterDecorator(innerXmlWriter))
        {
            myDoc.WriteTo(xmlTextWriter);
        }
        xmltext = stringWriter.ToString();
    }

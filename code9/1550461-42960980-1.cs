    string xmltext;
    using (var stringWriter = new StringWriter())
    {
        using (var xmlTextWriter = new FullElementXmlTextWriter(stringWriter))
        {
            myDoc.WriteTo(xmlTextWriter);
        }
        xmltext = stringWriter.ToString();
    }

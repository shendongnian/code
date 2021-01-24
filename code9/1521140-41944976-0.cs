    XmlWriterSettings settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    settings.ConformanceLevel = ConformanceLevel.Document;
    settings.CloseOutput = false;
    MemoryStream strm = new MemoryStream();
    using (XmlWriter writer = XmlWriter.Create(strm, settings))
    {
        writer.WriteStartElement("media");
        writer.WriteStartElement("cd");
        writer.WriteStartElement("burned");
        writer.WriteAttributeString("value", "true");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteStartElement("vinyl");
        writer.WriteStartElement("pressed");
        writer.WriteAttributeString("value", "true");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
    }
    string sMediaXML = Encoding.UTF8.GetString((strm).ToArray());
    Boolean bNodeExists;
    string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
    if (sMediaXML.StartsWith(_byteOrderMarkUtf8))
    {
        sMediaXML = sMediaXML.Remove(0, _byteOrderMarkUtf8.Length);
    }
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(sMediaXML);
    if (xmlDoc.SelectSingleNode("/media/cd/burned/@value").Value != null)
    {
        bNodeExists = true;
    }
    else
    {
        bNodeExists = false;
    }

    XmlDocument XMLDoc = new XmlDocument();
    XMLDoc.LoadXml(NewXML);
    foreach (XmlElement entry in XMLDoc.SelectNodes("//DataEntries"))
    {
        var data = entry.ChildNodes.OfType<XmlElement>().ToList();
        foreach (var d in data)
        {
            var e = XMLDoc.CreateElement(d.Attributes["Name"].Value);
            e.InnerText = d.InnerText;
            entry.AppendChild(e);
        }
        foreach (var d in data)
        {
            entry.RemoveChild(d);
        }
    }
    string EventDataJSON = JsonConvert.SerializeXmlNode(XMLDoc, 0, true);

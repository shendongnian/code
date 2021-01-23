        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("RootNode");
        xmlDoc.AppendChild(rootNode);
        foreach (Class objItem in classArray)
        {
            XmlNode firstNode= xmlDoc.CreateElement("First");
            XmlNode second= xmlDoc.CreateElement("Second");
            second.InnerText = objItem .Text;
            firstNode.AppendChild(second);
            rootNode.AppendChild(firstNode);
        }
        StringWriter stringWriter = new StringWriter();
        XmlTextWriter textWriter = new XmlTextWriter(stringWriter);
        xmlDoc.WriteTo(textWriter);

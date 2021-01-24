        XmlDocument XmlResponse = new XmlDocument();
    XmlDeclaration xDeclare = XmlResponse.CreateXmlDeclaration("1.0", "UTF-8", null);
    XmlElement documentRoot = XmlResponse.DocumentElement;
    XmlResponse.InsertBefore(xDeclare, documentRoot);
    XmlElement el = (XmlElement)XmlResponse.AppendChild(XmlResponse.CreateElement("TASKLOADLOG"));
    
    //List<XmlElement> ls = new List<XmlElement>();
    for (int i = 0; i < 3; i++)
    {
         XmlResponse.Root.AppendChild(new XElement("PERSON",
                new XElement("EMAIL", "data"),
                new XElement("LOADED", "OK"),
                new XElement("LOADERROR", "ABC")
        )));
    }
    
        
    
    MessageBox.Show(XmlResponse.OuterXml);

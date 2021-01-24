    public void AddShortcut(Shortcut s)
    {
        // 1. load existing xml
        xDoc.Load(FullPath);
        // 2. create an XML node from object
        XmlElement node = SerializeToXmlElement(s);
        // 3. append that node to XML root
        // Here you might want to go further down the nodes - 
        // I'm not sure what your requirements are
        xDoc.DocumentElement.AppendChild(node);
        // 4. save changes
        xDoc.Save(FullPath);
    }
    public static XmlElement SerializeToXmlElement(object o)
    {
        XmlDocument doc = new XmlDocument();
        using(XmlWriter writer = doc.CreateNavigator().AppendChild())
        {
            new XmlSerializer(o.GetType()).Serialize(writer, o);
        }
        return doc.DocumentElement;
    }

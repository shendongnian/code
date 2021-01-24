    public void AddShortcut(Shortcut s)
    {
        // 1. load existing xml
        xDoc.Load(FullPath);
        // 2. create an XML node from object
        XmlElement node = SerializeToXmlElement(s);
        // 3. append that node to Shortcuts node under XML root
        var shortcutsNode = xDoc.CreateElement("Shortcuts")
        shortcutsNode.AppendChild(node);
        xDoc.DocumentElement.AppendChild(shortcutsNode);
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

    XmlDocument doc2 = new XmlDocument();
    doc2.Load(@"Path\To\XmlFile.xml");
    XmlElement root = doc2.DocumentElement;
    XmlNodeList list = root.GetElementsByTagName("name");
            
    var names = list[0].ChildNodes;
    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine(names[i].InnerText);
    }

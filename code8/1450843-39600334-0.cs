    XmlDocument doc2 = new XmlDocument();
    doc2.Load(@"C:\Users\Rupert\Desktop\test.xml");
    XmlElement root = doc2.DocumentElement;
    XmlNodeList list = root.GetElementsByTagName("name");
            
    var names = list[0].ChildNodes;
    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine(names[0].InnerText);
        Console.WriteLine(names[1].InnerText);
        Console.WriteLine(names[2].InnerText);
    }

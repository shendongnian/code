    XmlDocument doc2 = new XmlDocument();
    doc2.Load("a.xml");
    XmlElement root = doc2.DocumentElement;
    XmlNodeList patients = root.GetElementsByTagName("patient");
    foreach (var patient in patients)
    {
        var element = (XmlElement) patient;
        Console.WriteLine(element.GetElementsByTagName("given")[0].InnerText);
        Console.WriteLine(element.GetElementsByTagName("given")[1].InnerText);
        Console.WriteLine(element.GetElementsByTagName("family")[0].InnerText);
        Console.WriteLine(element.GetElementsByTagName("birthTime")[0].Attributes[0].Value);
    }

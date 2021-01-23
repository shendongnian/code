    XmlDocument doc = new XmlDocument();
    doc.Load(_xmlFilePath);
    XmlNodeList nodelist = doc.SelectNodes("//result[@value=45]");
    for (int i = 0; i < nodelist.Count; i++)
    {
        double value = double.Parse(nodelist[i].InnerText);
        Console.WriteLine("value : " + value);
    }

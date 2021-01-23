    XmlDataDocument xmldoc = new XmlDataDocument();
    FileStream fs = new FileStream("test.xml", FileMode.Open,  FileAccess.Read);
    xmldoc.Load(fs);
    XmlNodeList _ngroups = xmldoc.GetElementsByTagName("Placemark");
    foreach(XmlNode nd in _ngroups)
    {
    Console.WriteLine(nd.ChildNodes[4].ChildNodes[0].InnerText.ToString());
    Console.WriteLine(nd.ChildNodes[4].ChildNodes[1].InnerText.ToString());
    }
  

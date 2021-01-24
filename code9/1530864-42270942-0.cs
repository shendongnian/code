    XmlDocument doc = new XmlDocument();
    doc.Load(@"c:\users\khaab\documents\visual studio 2015\Projects\ReadingXML\test.xml");
    var list = doc.DocumentElement["appSettings"];
    list.RemoveAll();
    foreach (var item in _settings)
    {
      XmlNode xNode = xDoc.CreateNode(XmlNodeType.Element, "add", "");
      XmlAttribute xKey = xDoc.CreateAttribute("key");
      XmlAttribute xValue = xDoc.CreateAttribute("value");
      xKey.Value = item.Key;
      xValue.Value = item.Value;
      xNode.Attributes.Append(xKey);
      xNode.Attributes.Append(xValue);
      xDoc.GetElementsByTagName("appSettings")[0].InsertAfter(xNode, xDoc.GetElementsByTagName("appSettings")[0].LastChild);
    }
    doc.Save(@"c:\users\khaab\documents\visual studio 2015\Projects\ReadingXML\test.xml");

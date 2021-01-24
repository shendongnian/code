    xmlDoc.Load(@"FILE_PATH");
    XmlNodeList header_el = xmlDoc.GetElementsByTagName("response");
    
    foreach (XmlNode child in header_el)
    {
      if (child.Attributes[0] != null)
      child.Attributes.Remove(child.Attributes[0]);
    }
    Console.WriteLine(xmlDoc.OuterXml);

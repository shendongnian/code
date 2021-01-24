    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("xmlFileLocation");
    XmlNodeList empNodes = xmlDoc.SelectNodes("//emp");
    foreach(XmlNode empNode in empNodes)
    {
        XmlNode nameNode = empNode.SelectSingleNode("Name");
        XmlNode idNode = empNode.SelectSingleNode("id");
        if((nameNode != null) && (idNode != null))
              Console.WriteLine( "Employee " + idNode.InnerText + " name is : " + nameNode.InnerText );
    }

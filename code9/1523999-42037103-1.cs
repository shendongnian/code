        var xml = new XmlDocument();
        xml.LoadXml(xmlstring);
        XmlNamespaceManager manager = new XmlNamespaceManager(xml.NameTable);
        manager.AddNamespace("ns1", "http://DefaultNamespace");
        //select all nodes using XPath
        var search = xml.SelectNodes("//ns1:getCustomersResponse/getCustomersReturn//getCustomersReturn",manager);
        //saving XmlNodeList to List<string>
        var r = new List<string>();
        foreach (XmlNode item in search)
            r.Add(item.InnerText);
        string[] ary = r.ToArray(); //convert List<string> to string[]

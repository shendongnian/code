        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("XMLFile1.xml");
        XmlNode mainNode = xmlDoc.SelectSingleNode("events");
        XmlNodeList nodeList = mainNode.ChildNodes;
        int random = Program.rand.Next(0, nodeList.Count - 1);
        XmlNode optionNode = nodeList[random];
        Console.WriteLine(mainNode.InnerText);
        Console.WriteLine(optionNode.InnerText);

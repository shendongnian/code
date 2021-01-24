    string entities = "Search_Results/Entity";           
    
    XmlNodeList nodes = xdoc.SelectNodes(entities);
    foreach (XmlNode node in nodes)
    {
        var accountID = node.SelectNodes("/Information/AccountID");
        Console.WriteLine("AccountID : " + accountID[0].InnerText);
    }

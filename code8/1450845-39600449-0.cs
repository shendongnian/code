    for (int i = 0; i < list.Count; i++)
    {
    	var xmlNode = list.Item(i).FirstChild;
    
    	while (xmlNode != null)
    	{
    		Console.WriteLine(xmlNode.InnerText);
    		xmlNode = xmlNode.NextSibling;
    	}
    }
    
    XmlNodeList birthDates = root.GetElementsByTagName("birthTime");
    
    for (int i = 0; i < list.Count; i++)
    {
    	Console.WriteLine(birthDates[i].Attributes["value"].Value);
    }

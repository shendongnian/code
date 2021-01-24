	bool hasMore = xmlReader.Read();
	while (hasMore)
	{
	    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "B")
	    {
	        Console.WriteLine(xmlReader.ReadOuterXml());
	    }
	    else hasMore = xmlReader.Read();
	}

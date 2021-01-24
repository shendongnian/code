	using (XmlReader xmlReader = XmlReader.Create(new StringReader(str)))
	{
	    while (xmlReader.Read())
	    {
	        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "B")
	        {
	            xmlReader.Read(); // Next read will contain the value
	            Console.WriteLine(xmlReader.Value);
	        }
	    }
	}

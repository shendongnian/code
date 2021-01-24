    string str = "<A><B>Apple</B><B>Mango</B></A>";
    
    using (XmlReader xmlReader = XmlReader.Create(new StringReader(str)))
    {
    	while (!xmlReader.EOF)
    	{
    		if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "B")
    		{
    			XElement xElement = XNode.ReadFrom(xmlReader) as XElement;
    			Console.WriteLine(xElement.ToString());		// This will print the tag
    			Console.WriteLine(xElement.Value);			// This will print the tag value
    		}
    		else
    		{
    			xmlReader.Read();
    		}
    	}
    }

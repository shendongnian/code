    StringBuilder output = new StringBuilder();
    using (XmlReader reader = XmlReader.Create(new StreamReader(value)))
    {
    	bool isValue = false;
    	while (reader.Read())
    	{
    		if (reader.NodeType == XmlNodeType.Element && reader.Name == "Value")
    		{
    			isValue = true;
    		}
    
    		if (reader.NodeType == XmlNodeType.Text && isValue)
    		{
    			output.AppendLine((output.Length == 0 ? "" : ", ") + reader.Value);
    			isValue = false;
    		}
    	}
    }

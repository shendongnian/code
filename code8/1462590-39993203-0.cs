    foreach (XElement e in elements)
    {
    	using (var reader = e.CreateReader())
    	{
    		var lineInfo = ((IXmlLineInfo)reader);
    		while (reader.Read())
    		{
    			if (reader.NodeType == XmlNodeType.EndElement && reader.Depth == 0)
    			{
    				Console.WriteLine($"{e.Name}"
    					+ $" - Open({((IXmlLineInfo)e).LineNumber},{((IXmlLineInfo)e).LinePosition})"
    					+ $" Close({lineInfo.LineNumber},{lineInfo.LinePosition})");
    			}
    		}
    	}
    }

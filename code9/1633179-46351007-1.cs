    static List<Node> ParseXML(string xmlContent)
    {
    	using (var reader = XmlReader.Create(new StringReader(xmlContent)))
    	{
    		var rootNodes = new List<Node>();
    		var nodeStack = new Stack<Node>();
    		while (reader.Read())
    		{
    			switch (reader.NodeType)
    			{
    				case XmlNodeType.Element:
    					var node = new Node { Name = reader.Name };
    					if (reader.MoveToFirstAttribute())
    					{
    						// Read the attributes
    						do
    						{
    							node.Attributes.Add(reader.Name, reader.Value);
    						}
    						while (reader.MoveToNextAttribute());
    						// Move back to element
    						reader.MoveToElement();
    					}
    					var nodes = nodeStack.Count > 0 ? nodeStack.Peek().Children : rootNodes;
    					nodes.Add(node);
    					if (!reader.IsEmptyElement)
    						nodeStack.Push(node);
    					break;
    
    				case XmlNodeType.EndElement:
    					nodeStack.Pop();
    					break;
    			}
    		}
    		return rootNodes;
    	}

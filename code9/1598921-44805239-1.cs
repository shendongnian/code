	private XmlWriter Writer { get; set; }
	private TextWriter InnerTextWriter { get; set; }
    public void Write(XDocument doc)
	{
		XElement root = doc.Root;
		WriteNode(root, 0);
	}
	private void WriteNode(XNode node, int currentNodeDepth)
	{
		if(node.NodeType == XmlNodeType.Element)
		{
			WriteElement((XElement)node, currentNodeDepth);
		}
		else if(node.NodeType == XmlNodeType.Text)
		{
			WriteTextNode((XText)node, currentNodeDepth, doIndentAttributes);
		}
	}
    private void WriteElement(XElement node, int currentNodeDepth)
    {
    	Writer.WriteStartElement(node.Name.LocalName);
    	
    	// Write attributes with indentation
		XAttribute[] attributes = node.Attributes().ToArray();
		if(attributes.Length > 0)
		{
			// First attribute, unindented.
			Writer.WriteAttributeString(attributes[0].Name.LocalName, attributes[0].Value);
			for(int i=1; i<attributes.Length; ++i)
			{
				// Write indentation
				Writer.Flush();
				string indentation = Writer.Settings.NewLineChars + string.Concat(Enumerable.Repeat(Writer.Settings.IndentChars, currentNodeDepth));
				indentation += string.Concat(Enumerable.Repeat(" ", node.Name.LocalName.Length + 1));
				// Using Underlying TextWriter trick to output whitespace
				InnerTextWriter.Write(indentation);
				Writer.WriteAttributeString(attributes[i].Name.LocalName, attributes[i].Value);
			}
		}
    
    	// output children
    	foreach(XNode child in node.Nodes())
    	{
    		WriteNode(child, currentNodeDepth + 1);
    	}
    
    	Writer.WriteEndElement();
    }

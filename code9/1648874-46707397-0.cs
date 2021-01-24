	static void traverse(XmlNodeList nodes, string parentPath)
	{
		foreach (XmlNode node in nodes)
		{
			string thisPath = parentPath;
			if (node.NodeType != XmlNodeType.Text)
			{
				//Prevent adding "#text" at the end of every chain
				thisPath += "/" + node.Name;
			}
			if (!node.HasChildNodes)
			{
				//Only print out this path if it is at the end of a chain
				Console.WriteLine(thisPath);
			}
			//Look into the child nodes using this function recursively
			traverse(node.ChildNodes, thisPath);
		}
	}

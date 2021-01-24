	XDocument parsedXml = new XDocument();
    parsedXml.AddFirst(new XElement("root"));
	using (var rdr = new XmlTextReader(fileName))
	{
		rdr.MoveToContent();
		rdr.Read();
		while (rdr.NodeType == XmlNodeType.Element)
		{
			switch (rdr.Name)
			{
				case "Node1":
				case "Node2":
				case "Node3":
					XElement newNode = XElement.Load(rdr.ReadSubtree());
					parsedXml.Root.Add(newNode);
					rdr.Read();
					break;
				default:
					rdr.Skip();
					break;
			}
		}
		rdr.Close();
	}

	public XmlModel GetXmlModel()
	{
		string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <root>
                <bar>1</bar>
                <bar>2</bar>
            </root>";
		var reader = XmlReader.Create(new StringReader(xml));
		reader.MoveToContent();		
		var data = new List<string>();
		
		while (reader.Read())
		{
			if (reader.NodeType == XmlNodeType.Element)
			{
				data.Add((XNode.ReadFrom(reader) as XElement).Value);
			}
		}
		return new XmlModel() {	Foo = data};
	}

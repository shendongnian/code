	public XmlModel GetXmlModel()
	{
		string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
            <root>
                    <bar>1</bar>
                    <bar>2</bar>
            </root>";
		using (var reader = XmlReader.Create(new StringReader(xml)))
		{
			reader.MoveToContent();
			var data = new List<string>();
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					var element = XNode.ReadFrom(reader) as XElement;
					switch (element.Name.LocalName)
					{
						case "bar":
							{
								data.Add(element.Value);
								break;
							}
					}
				}
			}
			return new XmlModel() { Foo = data };
		}
	}

    private void HandleNode(XmlNode node, XmlDocument xmlDoc)
		{
			if (node.HasChildNodes)
			{
				foreach (XmlNode child in node.ChildNodes)
				{
					if (node.ChildNodes[0].Name != "Descriptions" && node.Name != "Descriptions")
					{
						var trElement = createNode(xmlDoc);
						node.InsertBefore(trElement, node.ChildNodes[0]);
					}
					if (node.Name != "Descriptions")
						HandleNode(child, xmlDoc);
				}
			}
			else
			{
				var trElement = createNode(xmlDoc);
				node.InsertBefore(trElement, node.ChildNodes[0]);
			}
		}

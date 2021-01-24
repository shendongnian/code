		public String GetJson(XmlDocument xml)
		{
			XmlNodeList list = xml.SelectNodes("//comment()");
			foreach(XmlNode node in list)
			{
				node.ParentNode.RemoveChild(node);
			}
			
			var converter = new Newtonsoft.Json.Converters.XmlNodeConverter();
			// Use Newtonsoft.Json.Formatting.None in your production code
			return Newtonsoft.Json.JsonConvert.SerializeObject(xml, Newtonsoft.Json.Formatting.Indented, converter);
		}		

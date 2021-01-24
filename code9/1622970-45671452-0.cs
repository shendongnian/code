    private static string ConvertFileToXml()
		{
			string fileContent = File.ReadAllText("text.json");
			XmlDocument doc = JsonConvert.DeserializeXmlNode(fileContent, "root");
			return System.Web.HttpUtility.HtmlDecode(doc.SelectSingleNode("root").SelectSingleNode("bodyXML").InnerText);
		}

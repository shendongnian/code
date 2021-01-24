        XmlDocument xDoc = new XmlDocument();
		xDoc.LoadXml(s);
		
		XmlNode pathOfQuery = xDoc.SelectSingleNode("//PathOfQuery");
		string pathOfQueryValue = pathOfQuery.InnerText;
		Console.WriteLine(pathOfQueryValue);
		XmlNode define = xDoc.SelectSingleNode("//Define[@Name='" + pathOfQueryValue + "']");
		if(define!=null)
		{
			string defineTagValue = define.Attributes["Value"].Value;
			Console.WriteLine(defineTagValue);
			
			pathOfQuery.InnerText = defineTagValue;
			
			Console.WriteLine(pathOfQuery.InnerText);
		}

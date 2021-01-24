	XmlDocument xdoc = new XmlDocument();
	xdoc.Load(@"C:\temp\inifile.xml");
	XmlNodeList nodes = xdoc.SelectNodes("//Lijst");
	foreach (XmlNode node in nodes)
	{
		Console.WriteLine("this is List with title: " + node["Titel"].InnerText);
		Console.WriteLine("it contains wardes: " + node["Titel"].InnerText);
		XmlNodeList wardeNodes = node.SelectNodes("Waardes");
		foreach (XmlNode wNode in wardeNodes)
		{
			Console.WriteLine("   - " + wNode.InnerText);
		}
	}

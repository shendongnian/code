    var name = Console.ReadLine();
 
    using (XmlReader reader = XmlReader.Create(@"\\IPADDRESS\Customers\customers\GRACE-SVR1\XmlConfig\EXAMPLE.XML"))
	{
		while (reader.Read())
		{
			if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "CAMERA"))
			{
				if (reader.HasAttributes && reader.GetAttribute("name") == name)
				{
					Console.WriteLine(reader.GetAttribute("uid"));
				}
			}
		}
	}

	//search for  all nodes with <DBSimulatorConfiguration> element
	string xml = "<path>.DBConfig.xml";
	XDocument xdoc = XDocument.Load(xml);
	var elements = xdoc.Root.Elements().Elements().Where(x => x.Name == "DBSimulatorConfiguration");
	//iterate through all those eleemnt
	foreach (var element in elements)
	{
		//Console.WriteLine("Empty {0}", element.Value);
		//now find it's child named Submit
		var configKey = element.Elements().FirstOrDefault(x => x.Name == "Key");
		var configSubmit = element.Elements().FirstOrDefault(x => x.Name == "Submit");
		var configAmend = element.Elements().FirstOrDefault(x => x.Name == "Amend");
		var configUpdate = element.Elements().FirstOrDefault(x => x.Name == "Update");
		var configDelete = element.Elements().FirstOrDefault(x => x.Name == "Delete");
		
		//if such element is found
		if (configSubmit != null)
		{
			if (configKey.ElementsBeforeSelf().Any(x => x.Name == "Key" && x.Value == "Test1"))
			{
				Console.WriteLine("Found Key for Test1 {0}", configKey.Value);
			}
			if (configSubmit.ElementsBeforeSelf().Any(x => x.Name == "Key" && x.Value == "Test1"))
			{
				configSubmit.Value = "1";
				Console.WriteLine("Submit value is updated to {0}", configSubmit.Value);		
			}
			if (configAmend.ElementsBeforeSelf().Any(x => x.Name == "Key" && x.Value == "Test1"))
			{
				Console.WriteLine("Amend value is: {0}", configAmend.Value);
			}
			if (configUpdate.ElementsBeforeSelf().Any(x => x.Name == "Key" && x.Value == "Test1"))
			{
				Console.WriteLine("Update value is: {0}", configUpdate.Value);
			}
		}
	}
	xdoc.Save("<path>.DBConfig.xml");

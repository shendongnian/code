	var employees = new Employees
	{
		Employee = new List<Employee>()
		{
			new IT("Sugan", "88"),
			new HR("Niels", "41")
		}
	};
	
	var serializer = new XmlSerializer(typeof(Employees));
	var xml = "";
	
	using (var sw = new StringWriter())
	{
		using (XmlWriter writer = XmlWriter.Create(sw))
		{
			serializer.Serialize(writer, employees);
			xml = sw.ToString();
		}
	}
	Console.WriteLine(xml);

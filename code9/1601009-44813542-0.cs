	var props = typeof(Car).GetProperties();
	var stb = new StringBuilder();
	foreach (var element in MyCarList)
	{
		foreach (var prop in props)
		{
			stb.Append(prop.Name);
			stb.Append(": ");
			stb.Append(prop.GetValue(element));
			stb.AppendLine();
		}
		stb.AppendLine("--------------------------");
	}

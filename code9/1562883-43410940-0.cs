	var tests = new[]{"Lastname, FirstName", "Lastname, ", ", FirstName", "Lastname", "FirstName"};
	foreach(var str in tests)
	{
		var strArr = str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Reverse()
			.Select(x => x.Trim());
		var output = string.Join(" ", strArr);
		Console.WriteLine(output);
	}

	foreach (var i in mainList)
	{
		switch (i)
		{
			case IEnumerable<object> li:
				Console.WriteLine($"List: {string.Join(", ", li)}");
				break;
			default:
				Console.WriteLine(i);
				break;
		}
	}

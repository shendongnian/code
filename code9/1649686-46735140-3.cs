	var data = new SortedMultiValue<string, string>();
	data.Add("Dog", "Buddy");
	data.Add("Dog", "Mr. Peanutbutter");
	data.Add("cat", "Charlie");
	data.Add("cat", "Sam");
	data.Add("cat", "Leo");
	
	foreach (string item in data)
	{
		Console.WriteLine(item);
	}
	
	Console.WriteLine();
	foreach (string item in data.Get("cat"))
	{
		Console.WriteLine(item);
	}
	
	Console.WriteLine();
	foreach (string item in data.Get("Dog"))
	{
		Console.WriteLine(item);
	}

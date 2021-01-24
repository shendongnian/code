	var values = Enumerable.Range(1, 10)
						   .Select(value => new Element(typeof(int), value.ToString()))
						   .Select(element => Convert.ChangeType(element.Value, element.ArrayType))
						   .ToArray();
	
	foreach(var value in values)
	{
		Console.WriteLine(value + " " + value.GetType());
	}

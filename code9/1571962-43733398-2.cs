	var types = new[] { typeof(int), typeof(float), typeof(double) };
	var elements = Enumerable.Range(1, 100)
						   .Select((value, index) => new Element(types[index % types.Length], value.ToString()));
	
	var integers = elements.Where(element => element.ArrayType == typeof(int))
						   .Select(element => (int)Convert.ChangeType(element.Value, element.ArrayType))
						   .ToArray();
	
	Console.WriteLine(integers.GetType());
	
	foreach(var value in integers)
	{
		Console.WriteLine(value + " " + value.GetType());
	}

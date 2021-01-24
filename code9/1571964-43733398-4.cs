	var types = new[] { typeof(int), typeof(float), typeof(double) };
	var elements = Enumerable.Range(1, 100)
						   .Select((value, index) => new Element(types[index % types.Length], value.ToString(), index));
	
	var integers = elements.Where(element => element.ArrayType == typeof(int));
	var array = Array.CreateInstance(typeof(int), 100);
	
	Console.WriteLine(array.GetType());
	
	foreach(var element in integers)
	{
		var value = Convert.ChangeType(element.Value, element.ArrayType);
		array.SetValue(value, element.Index);
	}
	
	foreach(var value in array)
	{
		Console.WriteLine(value + " " + value.GetType());
	}

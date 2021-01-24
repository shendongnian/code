    string value = Console.ReadLine();
	var negative = value.StartsWith("-");
	
	var newValue = value.Replace("-", string.Empty);
	var numbers = newValue
		.Select(c => (int)char.GetNumericValue(c))
		.ToArray();
		
	Array.Sort(numbers);
	
	if (negative) Array.Reverse(numbers);
	
	foreach (var item in numbers){ 
		Console.Write(item);
	}

	public static void someFunction(object input)
	{
		foreach (var p in input.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
				 Console.WriteLine("{0}={1}", p.Name, p.GetValue(input));
	}
		

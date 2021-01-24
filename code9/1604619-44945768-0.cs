	var knownPropNames = new string[]
	{
		"Int", 
		"Str", 
	};
	var props = typeof(Foo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
	var unknownProps = props
						.Where(x => !knownPropNames.Contains(x.Name))
						.Select(x => x.Name)
						.ToArray();
    // Use assertion instead of Console.WriteLine
	Console.WriteLine("Unknown props: {0}", string.Join("; ", unknownProps));

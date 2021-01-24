    //Get all the types that inherit from 'X'
	var types = Assembly.GetExecutingAssembly().GetTypes()
		.Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(X)))
		.ToList();
	
	Console.WriteLine("Choose a class to run");
	var index = 0;
	foreach (var type in types)
	{
		Console.WriteLine($"{index++}: {type.Name}");
	}
	
	Console.Write("Enter number: ");
	
    //Much better to use "TryParse" here and validate the input
	index = int.Parse(Console.ReadLine());
	
	var instance = (X)Activator.CreateInstance(types[index]);
	
	instance.SomeFunction();

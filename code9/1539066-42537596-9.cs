	try
	{
		// use parameterized constructor
		Man p = new Man("Dan"); 
		// or use an initializer
		Man p = new Man{Name = "Dan"}; 
		// the above initializer is actually short for
		Man p = new Man(); 
		p.Name = "Dan"; 
	}
	catch (ArgumentException e)
	{
		Console.WriteLine("Error occurred!! Do something...");
	}

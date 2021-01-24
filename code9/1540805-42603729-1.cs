    try 
    {
		Console.WriteLine("1");
		throw new Exception();
	}
	catch(Exception) 
    {
		Console.WriteLine("2");
	}
	finally 
    {
		Console.WriteLine("3");
	}
	Console.WriteLine("4");
	return;

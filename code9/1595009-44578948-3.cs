	string x;
	int result;
	while (true)
	{
		x = Console.ReadLine();
		try
		{
			result = int.Parse(x);
			Console.WriteLine("int input");
		}
		catch
		{
			Console.WriteLine("Invalid input ");
		}
	}

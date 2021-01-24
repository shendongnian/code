	var reg = new Regex("^-?\\d+$");
	string result;
	Match m;
	for (;;)
	{
		result = Console.ReadLine();
		m = reg.Match(result);
		if(m.Success)
		{
			Console.WriteLine("int input");
		}
		else
		{
			Console.WriteLine("Invalid input: ");
		}
	}

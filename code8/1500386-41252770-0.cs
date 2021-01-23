	void Main()
	{
		var TestString = Console.ReadLine();
		int Integer;
		if (int.TryParse(TestString, out Integer))
		{
			int Test = Integer; // maybe you dont need this
		}
		else
		{
			Console.WriteLine("::INVALID::");
	    }
	}

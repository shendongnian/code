	int count = 0;
	decimal input = 0;
	decimal price = 0;
	while (true)
	{
		Console.Write("Item {0} Enter Price: ", count++);
		input = Convert.ToDecimal(Console.ReadLine());
		if (input == -1)
		{
			break;
		}
		price += input;
	}

	do
	{
		Console.WriteLine("Please type a positive number or 0");
		int input;
		if (int.TryParse(Console.ReadLine(), out input)
		    && input >= 0) // You can validate the input at the same time
		{
			acresToBuy = input;
		}
		else
		{
			Console.WriteLine("That was not the correct input. Please try again.");
		}
	} while (acresToBuy < 0);

	string[] ColorsArray = new string[12] { "blue", "red", "green", "yellow", "blue", "green", "blue", "yellow", "red", "green", "red", "yellow" };
	float[] LengthArray = new float[12] { 1.3f, 1.4f, 5.6f, 1.5f, 3.5f, 5.4f, 1.2f, 6.5f, 4.4f, 4.1f, 3.3f, 4.9f };
	Console.WriteLine("Select a color of Fish by entering the corresponding number \r\n 1. Blue \r\n 2. Yellow \r\n 3. Red \r\n 4. Green");
	bool asking = true;
	while (asking)
	{
		string ColorChoiceNumber = Console.ReadLine();
		int ColorChoiceNumberInt;
		if (int.TryParse(ColorChoiceNumber, out ColorChoiceNumberInt))
		{
			if (ColorChoiceNumberInt >= 1 && ColorChoiceNumberInt <= 4)
			{
				asking = false;
				string[] fish = new string[] { "Blue", "Yellow", "Red", "Green" };
				Console.WriteLine("The Biggest {0} Fish is Fish Number ", fish[ColorChoiceNumberInt - 1]);
			}
			else
			{
				Console.WriteLine("Please only enter a number. It must be 1-4.");
			}
		}
		else
		{
			Console.WriteLine("Please only enter a number. It must be 1-4.");
		}
	}

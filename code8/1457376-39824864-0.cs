	char[] charArray = new char[7];
	Console.WriteLine("Enter {0} unique alphabetic characters: ", charArray.Length);
	int i = 0;
	while (i < charArray.Length)
	{
		char inputChar = Console.ReadKey().KeyChar;
        Console.WriteLine();
		if (charArray.Contains(inputChar))
		{
			Console.WriteLine("Please enter a unique alphabetic character.");
		}
		else
		{
			charArray[i] = inputChar;
			++i;
		}
	}
	Console.WriteLine(charArray);

	public static string Backwards() // Create Backwards Method
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Create a sentence with at least 6 words");
		string userSentence = Console.ReadLine();
		if (userSentence.Length <= 6)
		{
			userSentence = String.Join(" ", userSentence.Split(' ').Reverse())
		}
	}
	

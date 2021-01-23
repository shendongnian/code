	public static string Backwards() // Create Backwards Method
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Create a sentence with at least 6 words");
		string userSentence = Console.ReadLine();
		//To count the number of words used split.length
		if(userSentence.Split(' ').Length <= 6)
		{
			userSentence = String.Join(" ", userSentence.Split(' ').Reverse());
		}
		return userSentence;
	}
	

    public static void Main()
	{
		//Prompt user for sentence
		Console.WriteLine("Please enter a sentence with at least 5 words:");
		string userSentence = Console.ReadLine();
		string reversed = Reverse(userSentence);
		Console.WriteLine(reversed);
	}
	public static string Reverse(string data)
	{
		char[] dataArray = data.ToCharArray();
		Array.Reverse(dataArray);
		return new string (dataArray);
	}

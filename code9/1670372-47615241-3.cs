	private static int AskInteger(string message)
	{
		int result;
		Console.WriteLine(message);
		string input = Console.ReadLine();
		while (!int.TryParse(input, out result))
		{
			Console.WriteLine("Invalid input.");
			Console.WriteLine(message);
			input = Console.ReadLine();
		}
		return result;
	}
	
	private static string AskString(string message)
	{
		Console.WriteLine(message);
		string input = Console.ReadLine();
		while (string.IsNullOrWhiteSpace(input))
		{
			Console.WriteLine("Invalid input.");
			Console.WriteLine(message);
			input = Console.ReadLine();
		}
		return input;
	}	
	
	private static Gender AskGender(string message)
	{
		Gender result;
		Console.WriteLine(message);
		string input = Console.ReadLine();
		while (!Gender.TryParse(input, out result))
		{
			Console.WriteLine("Invalid input.");
			Console.WriteLine(message);
			input = Console.ReadLine();
		}
		return result;
	}

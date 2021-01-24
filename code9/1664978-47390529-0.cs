	public static int Ask(string message)
	{
		int result = -1;
		bool valid = false;
		while (!valid)
		{
			Console.WriteLine(message);
			valid = int.TryParse(Console.ReadLine(), out result);
		}
		return result;
	}

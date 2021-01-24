    static void Main(string[] args)
	{
		Console.Write("Enter source path: ");
		var _sourcePath = GetInput();
		Console.Write("Enter destination path: ");
		var _destinationPath = GetInput();
		Console.Write("Do you want detailed information displayed during the copy process? ");
		var response = GetInput();
		var _detailedReport = response?.Substring(0, 1)
			.Equals("y", StringComparison.CurrentCultureIgnoreCase);
	}
	private static string GetInput()
	{
		var input = Console.ReadLine();
		if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
			Environment.Exit(Environment.ExitCode);
		return input;
	}

	void Main()
	{
		Console.WriteLine(GetAllSubstrings('a', 'b', 'c'));	
		Console.WriteLine(GetAllSubstrings(2, 11, 8));	
	}
	
	// Define other methods and classes here
	public IEnumerable<string> GetAllSubstrings(params object[] args)
	{
		for (int i = 1; i <= args.Length; i++)
		{
			for (int j = 0; j <= (args.Length - i); j++)
			{
				yield return string.Join(string.Empty, args.Skip(j).Take(i));
			}
		}
	}

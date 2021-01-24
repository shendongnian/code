	for (long n = 0; n <= 9999999999; n++)
	{
		string digits = n.ToString("0000000000");
		string output = $"JI-{digits.Substring(0, 6)}-{digits.Substring(6, 4)}";
		Console.WriteLine(output);
	}

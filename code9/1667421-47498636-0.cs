	static void Main(string[] args)
	{
		string codes = "a 100100 b 100101 c 110001 d 100000 [newline] 111111 p 111110 q 000001";
		string encoded = "111110000001100100111111100101110001111110";
		Console.WriteLine("");
		try
		{
			string decoded = decode(codes, encoded);
			
			Console.WriteLine("codes:");
			Console.WriteLine(codes);
			Console.WriteLine("");
			Console.WriteLine("encoded: ");
			Console.WriteLine(encoded);
			Console.WriteLine("");
			Console.WriteLine("decoded: ");
			Console.WriteLine(decoded);
		}
		catch(Exception ex)
		{
			Console.WriteLine("Decoding Failed.");
			Console.WriteLine("Reason: " + ex.Message);
		}
		Console.WriteLine("");
		Console.Write("Press [Enter] to exit...");
		Console.ReadLine();
	}
	static string decode(string codes, string encoded)
	{
		StringBuilder decoded = new StringBuilder();
		List<Tuple<string, string>> codePairs = new List<Tuple<string, string>>();
		string[] codeValues = codes.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		if (codeValues.Length % 2 != 0)
		{
			throw new Exception("Invalid number of code pairs!");
		}
		for (int i = 0; i < codeValues.Length - 1; i = i + 2)
		{
			if (codeValues[i].ToLower() == "[newline]")
			{
				codePairs.Add(new Tuple<string, string>(Environment.NewLine, codeValues[i + 1]));
			}
			else
			{
				codePairs.Add(new Tuple<string, string>(codeValues[i], codeValues[i + 1]));
			}
		}
		Boolean matchFound;
		while(encoded.Length > 0)
		{
			matchFound = false;
			foreach(Tuple<string, string> codePair in codePairs)
			{
				if (encoded.StartsWith(codePair.Item2))
				{
					encoded = encoded.Remove(0, codePair.Item2.Length);
					decoded.Append(codePair.Item1);
					matchFound = true;
					break;
				}
			}
			if (!matchFound)
			{
				throw new Exception("Invalid encoded string!  No matching code found.");
			}
		}
		
		return decoded.ToString();
	}

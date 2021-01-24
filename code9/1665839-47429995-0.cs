		Console.Write("Skriv in sökOrd: [TRUE|FALSE]");
		string searchWord = Console.ReadLine();
		bool search = Convert.ToBoolean(searchWord);
		for (int i = 0; i < boolVektor.Length; i++)
		{
			if (boolVektor[i] == search)
			{
				Console.WriteLine("The following were found: " + boolVektor[i] + 
				"Index: " + i);
			}
			if (!search)
			{
				Console.WriteLine("Your search failed");
			}
		}

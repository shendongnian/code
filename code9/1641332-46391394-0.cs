	static readonly Regex ingredientRegex = new Regex("(Salt|Sugar|Pepper)", RegexOptions.Compiled | RegexOptions.CultureInvariant);
	static void FindIngredient(string[] myList)
	{
		foreach(string x in myList)
		{
			var match = ingredientRegex.Match(x);
		    if(match.Success)
		    {
		    	Console.WriteLine("The ingredient found in this line of myList is: " + match.Groups[1].Value);
		    }
		}
	}

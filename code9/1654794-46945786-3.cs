    public static void Main()
	{
     	Console.WriteLine(FinalOutput("HelloHowAreYou?"));	
	}
	static string FinalOutput(string test)
	{
		var final = "";
		bool firstCharacterCheckIsDone = false;
		foreach (char c in test)
		{
			if (char.IsUpper(c))
			{
				if (test.IndexOf(c) == 0 && !firstCharacterCheckIsDone)
				{
					final += " " + c.ToString();
					
					//This here will make sure only first character is in Upper case
					//doesn't matter if the same character is being repeated elsewhere
					firstCharacterCheckIsDone = true; 
				}
				else
					final += " " + c.ToString().ToLower();
			}
			else
				final += c.ToString();
		}
		return final.Trim();
	}

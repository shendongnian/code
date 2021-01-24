    var test = "HelloHowAreYou";
		var final = "";
		bool firstCharacterCheckIsDone = false;
		foreach (char c in test)
		{
			if (char.IsUpper(c))
			{
				if (test.IndexOf(c) == 0 && !firstCharacterCheckIsDone)
				{
					final += " " + c.ToString();
					firstCharacterCheckIsDone = true;
				}
				else
					final += " " + c.ToString().ToLower();
			}
			else
				final += c.ToString();
		}
		Console.WriteLine(final.Trim());

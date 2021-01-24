    static void TestRegex()
    {
    	string s = "Web Application Developer in Acme Infosystem Mohali from 13 Nov 2014 to till present yii2 framework and Node JS.";
    	string pattern = 
    		@"(?x)
    		(3[01]|2[0-9]|1[0-9]|0[1-9])                    # Matches a day
    		\s+                                             # Matches spaces
            (Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)   # Matches month
            \s+                                             # Matches space
    	    [0-9]{4}                                        # Matches year";
    	string firstDate = null, secondDate = null;
    	var firstMatch = Regex.Match(s, pattern);
    	if (firstMatch.Success)
    	{
    		firstDate = firstMatch.Value;
            // If first date is found, try to match second date
    		var secondMatch = firstMatch.NextMatch();
    		if (secondMatch.Success)
    		{
    			secondDate = secondMatch.Value;
    		}
    		else
    		{
    			secondDate = Regex.IsMatch(s, "to till present") ? "till present" : null;
    		}
    	}
    	else
    	{
    		Console.WriteLine("First date not found.");
    	}
    	Console.WriteLine($"First date: '{firstDate}', secondDate: '{secondDate}'");
    }

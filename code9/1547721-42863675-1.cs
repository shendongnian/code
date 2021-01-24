	string knihaRef = System.IO.File.ReadAllText("Osnova.txt").ToLower();
	int[] numOfLet =new int[26];
	foreach(char c in knizka)
	{
	    // Only count letters.
		if ('a' < c && c < 'z')
		{
			numOfLet[c-'a']++;
		}
	}

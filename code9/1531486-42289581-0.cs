		// Checks whether all character in word is present in another word
        Func<string, string, bool> isContain = (s1, s2) =>
        {
	        int matchingLength = 0;
	        foreach (var c2 in s2.ToCharArray())
	        {
		        foreach (var c1 in s1.ToCharArray())
		        {
			        if (c1 == c2)
				        ++matchingLength;
		        }
	        }
			// if matched length is equal to word length given, it would be assumed as matched
			return s2.Length == matchingLength;
        };
		List<string> testList = new List<string>() { "can", "rock", "bird" };
        string name = "irb";
        var fileredList = testList.Where(x => isContain(x, name));

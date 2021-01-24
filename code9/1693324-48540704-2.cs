	public static bool IsBracketNestingValid(string input) {
		
		if (string.IsNullOrWhiteSpace(input)) {
			return true; // empty string is always nested correctly
		}
		
		const string openingBracket = "<:";
        const string closingBracket = ":>";
        if (input.Length < openingBracket.Length) {
            // perform this check if we expect that input strings 
            // must contain at least one bracket (e.g. "<" should be invalid)
		    return false; 
		}
		
		int openingCount = 0;
		int closingCount = 0;
		for (int pos = 0; pos < input.Length-1; pos++) {
			
			string currentToken = string.Format("{0}{1}", input[pos], input[pos+1]);			
			
			if (currentToken == openingBracket) {
				openingCount++;
                // skip over this recognized token 
                // (so we do not count any ':' twice, e.g. "<:>" should be invalid)
                pos++; 
			}
			
			if (currentToken == closingBracket) {
				closingCount++;
                pos++; // skip over this recognized token
			}
			
			if (closingCount > openingCount) {
				return false; // found closing bracket before opening bracket
			}
		}
		
		return openingCount == closingCount;
	}

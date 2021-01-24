	public static bool IsBracketNestingValid(string input) {
		
		if (string.IsNullOrWhiteSpace(input)) {
			return true; // empty string is always nested correctly
		}
		
		const string openingBracket = "<:";
        const string closingBracket = ":>";
        if (input.Length < openingBracket.Length) {
		    return false; // if we expect that input strings must contain at least one bracket	
		}
		
		int openingCount = 0;
		int closingCount = 0;
		for (int pos = 0; pos < input.Length-1; pos++) {
			
			string currentToken = string.Format("{0}{1}", input[pos], input[pos+1]);			
			
			if (currentToken == openingBracket) {
				openingCount++;
			}
			
			if (currentToken == closingBracket) {
				closingCount++;
			}
			
			if (closingCount > openingCount) {
				return false; // found closing bracket before opening bracket
			}
		}
		
		return openingCount == closingCount;
	}

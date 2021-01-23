    //Compares counts of each letter in word and tiles
    bool WordCanBeMadeFromLetters(string word, string tileLetters) {
	    var tileLetterCounts = GetLetterCounts(tileLetters);
	    var wordLetterCounts = GetLetterCounts(word);
	
        return wordLetterCounts.All(letter =>
            tileLetterCounts.ContainsKey(letter.Key)
            && tileLetterCounts[letter.Key] >= letter.Value);
    }
    //Gets dictionary of letter/# of letter in word
    Dictionary<char, int> GetLetterCounts(string word){
	    return word
	        .GroupBy(c => c)
		    .ToDictionary(
	    	    grp => grp.Key,
			    grp => grp.Count());
    }

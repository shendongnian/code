    public static IEnumerable<List<string>> StrangeLoop(string source)
    {
        // If word separators is anything other than whitespaces 
        // then change parameters for Split
    	var words = source.Split(null); 
    	for (int i = 0; i < words.Length - 2; i++)
    	{
    		yield return new List<string>() { words[i], words[i + 1], words[i + 2] };
    	}
    }
	var sentence = "Regex for taking out words out of a string from a specific position";
	
	foreach (var triad in StrangeLoop(sentence))
	{
		//use triad
	}

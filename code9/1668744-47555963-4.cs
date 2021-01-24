    var words = InputString.Split(' ');
    var result = new StringBuilder();
	
	var first = true;
    foreach (var word in words)
    {
	 	if (first)
		{
			first = false;
		}
		else
		{
			result.Append(' ');
		}
        if (dictionary.ContainsKey(word))
        {
            result.Append(dictionary[word]);
        }
        else
        {
            result.Append(word);            
        }
    }
    Console.WriteLine(result.ToString());

    var words = InputString.Split(' ');
    var result = new List<string>();
	
    foreach (var word in words)
    {
        if (dictionary.ContainsKey(word))
        {
            result.Add(dictionary[word]);
        }
        else
        {
            result.Add(word);            
        }
    }
    Console.WriteLine(string.Join(" ", result));

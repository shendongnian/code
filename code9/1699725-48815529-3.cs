	List<string> myList = new List<string>{ "dog", "cat", "dog", "bird" };
	
    //map out a count of all the duplicate words in dictionary.
	var counts = myList
	    .GroupBy(s => s)
        .Where(p => p.Count() > 1)
	    .ToDictionary(p => p.Key, p => p.Count());
    //modify the list, going backwards.
	for (int i = myList.Count - 1; i >= 0; i--)
	{
		string s = myList[i];
		if (counts.ContainsKey(s))
		{
			myList[i] += $" ({counts[s]--})";
		}
	}

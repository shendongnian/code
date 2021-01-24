	List<string> myList = new List<string>{ "dog", "cat", "dog", "bird" };
	
    //map out a count of all the words in dictionary.
	var counts = new Dictionary<string, int>();
	foreach (var s in myList)
	{
        int current;
        counts.TryGetValue(s, out current); 
        counts[s] = currentCount + 1;
	}
    //keep only the counts where we need to add a suffix.
	counts = counts.Where(p => p.Value > 1).ToDictionary(p => p.Key, p => p.Value);
    //modify the list, going backwards.
	for (int i = myList.Count - 1; i >= 0; i--)
	{
		string s = myList[i];
		if (counts.ContainsKey(s))
		{
			myList[i] += $" ({counts[s]})";
			counts[s]--;
		}
	}

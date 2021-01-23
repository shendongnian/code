    List<T> oldList = new List<T> { Soc1, Soc2, Soc3 };
	List<T> newList = new List<T> { Soc1, Soc3, Soc4 };
	int i = 0;
    // Go trough the old list to remove items which don't exist anymore
	while(i < oldList.Count)
	{
        // If the new list doesn't contain the old element, remove it from the old list
		if (!newList.Contains(oldList[i]))
		{
			oldList.RemoveAt(i);
		}
        // Otherwise move on
		else
		{
			i++;
		}
	}
    // Now go trough the new list and add all elements to the old list which are new
	foreach(T k in newList)
	{
		if (!oldList.Contains(k))
		{
			oldList.Add(k);
		}
	}

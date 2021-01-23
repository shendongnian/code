	var listToAdd = new List<int>();
    var listOdd = new List<int>();
	for(int i = 0; i < lst.Count; i++)
	{
		if(lst[i] == numberToBeMovedOnTop)
		{
			listToAdd.Add(numberToBeMovedOnTop);
		}
        else
        {
            listOdd.Add(lst[i]);
        }
	}
	listOdd.AddRange(listToAdd);

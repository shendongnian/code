    int maximumNumberElements = listContainer.Max(l => l.Count);
    List<int> resultList = new List<int>();
		
	for(int i = 0; i < maximumNumberElements; i++)
	{
	    resultList.Add(0);
	}
    
    for(int i = 0; i < listContainer.Count; i++)
    {
        for(int j = 0; j < listContainer[i].Count; j++)
        {
            resultList[j] += listContainer[i][j];
        }
    }

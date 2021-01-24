    for (int i = 0; i < tmp.Count; i++)
    {
    	if (tmp[i] > actualMax)
    	{
    		actualMax = tmp[i];
    	}
    	iterationMax++;
    
    	if (iterationMax > A)
    	{
    		listMax.Add(actualMax);
    		actualMax = 0;
    		iterationMax = 1;
    	}
    }

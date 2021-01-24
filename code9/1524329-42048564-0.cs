	var enumerator = sr.ReadLines((char)someEOL).GetEnumerator();
	 
	for (int i = 1;; i++)
	{
		bool isValid = enumerator.MoveNext();
	
	    if (isValid)
		{
			list.Add(enumerator.Current);
		}
		
		if (i % 100 ==  0)
		{
			SaveToDB(list);
				
			// It is better to clear the list than creating new one for each iteration, given that your file is big.
			list.Clear();
		}
		else if (!isValid && list.Count() > 0)
		{
			SaveToDB(list);
			break;
		}
	}

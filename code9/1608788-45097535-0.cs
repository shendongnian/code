	List<string> list =  new List<string>();
	
	for (int i = list.Count-1; i > 0 ; i--)
	{
		if (list[i] == list[i-1])
		{
			list.RemoveAt(i);
		}
	}

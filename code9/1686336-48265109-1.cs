    var result = new List<List<int?>>();
	for(int i = 0; i < 6; i++)
	{
		result.Add(new List<int?>());
		for(int j = 0; j < 3; j++)
		{
			if(lists[j].Contains(i))
				result[i].Add(i);
			else
				result[i].Add(null);
		}
	}

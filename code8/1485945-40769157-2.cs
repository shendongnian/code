	static IEnumerable<T> XYZ<T>(IEnumerable<IList<T>> lists)
	{
		if (lists == null)	
			throw new ArgumentNullException();
		var index = 0;
	
		while (lists.Any(l => l.Count > index))
		{
			foreach (var list in lists)		
				if (list.Count > index)			
					yield return list[index];		
			index++;
		}
	}

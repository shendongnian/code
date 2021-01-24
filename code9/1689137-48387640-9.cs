    public static class EnumerableExtensions
    {
    	public static IEnumerable<IEnumerable<int>> GroupConsecutive(this IEnumerable<int> list)
    	{
    		if (list.Count() == 0)
    		{
    			yield return Enumerable.Empty<int>();
    		}
    		var count = 0;
    		var startNumber = list.First();
    		int last = startNumber - 1;
    
    		foreach (var i in list)
    		{
    			if (i - 1 == last)
    				count += 1;
    			else
    			{
    				yield return Enumerable.Range(startNumber, count);
    				startNumber = i;
    				count = 1;
    			}
    			last = i;
    		}
    		yield return Enumerable.Range(startNumber, count);
    	}
    }

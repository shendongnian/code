    public static class IEnumerableExtensions
    {
    	public static IEnumerable<IEnumerable<int>> GroupConsecutive(this IEnumerable<int> list)
    	{
    		if (!list.Any()) {yield break;}
    		var count = 0;
    		var startNumber = list.First();
    		var last = startNumber - 1;
    
    		foreach (var i in list)
    		{
    			if (i - 1 == last)
                {
    				count += 1;
                }
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

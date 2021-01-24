    public static class EnumerableExtensions
    {
    	public static IEnumerable<IEnumerable<int>> GroupConsecutive(this IEnumerable<int> list)
    	{
    		if (list.Any())
    		{
    			var count = 1;
    			var startNumber = list.First();
    			int last = startNumber;
    
    			foreach (var i in list.Skip(1))
    			{
    				if (i < last)
    				{
    					throw new ArgumentException($"List is not sorted.", nameof(list));
    				}
    				if (i - last == 1)
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
    }

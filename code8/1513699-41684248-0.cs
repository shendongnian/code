    public static class Extensions
    {
    	public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, T, bool> splitOn)
    	{
    		using (var e = source.GetEnumerator())
    		{
    			for (bool more = e.MoveNext(); more; )
    			{
    				var last = e.Current;
    				var group = new List<T> { last };
    				while ((more = e.MoveNext()) && !splitOn(last, e.Current))
    					group.Add(last = e.Current);
    				yield return group;
    			}
    		}
    	}
    }

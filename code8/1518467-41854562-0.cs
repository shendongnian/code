    public static class LinqExtensions
    {
    	public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> splitOn)
    	{
    		using (var e = source.GetEnumerator())
    		{
    			for (bool more = e.MoveNext(); more;)
    			{
    				var group = new List<T> { e.Current };
    				while ((more = e.MoveNext()) && !splitOn(e.Current))
    					group.Add(e.Current);
    				yield return group;
    			}
    		}
    	}
    }

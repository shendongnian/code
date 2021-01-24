    public static IEnumerable<T> RemoveConsecutiveDuplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> comp = null)
    {
    	comp = comp ?? EqualityComparer<T>.Default;
    
    	using (var e = source.GetEnumerator())
    	{
    		if (e.MoveNext())
    		{
    			T last = e.Current;
    			yield return e.Current;
    
    			while (e.MoveNext())
    			{
    				if (!comp.Equals(e.Current, last))
    				{
    					yield return e.Current;
    					last = e.Current;
    				}
    			}
    		}
    	}
    }

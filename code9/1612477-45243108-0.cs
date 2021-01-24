    public static class ExtensionMethods
    {
    	public static IEnumerable<ValueTuple<T, T>> Merge<T>(this List<T> a, List<T> b)
    	{
    		for (int x = 0, y = 0; x < a.Count && y < a.Count; x++, y++) 
    		{
    			yield return ValueTuple.Create(a[x], b[y]);
    		}
    	}
        public static void ForEach<T>(this IEnumerable<T> s, Action<T> m)
        {
           foreach (var i in s) m(i);
        }
    }

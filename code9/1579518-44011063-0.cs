    public static class Ext {
	    public static IEnumerable<T1> WhereOther<T1, T2>(this IEnumerable<T1> src, IEnumerable<T2> filter, Func<T2, bool> pred) {
		    using (var isrc = src.GetEnumerator())
    		using (var ifilter = filter.GetEnumerator())
	    		while (ifilter.MoveNext())
					if (isrc.MoveNext())
						if (pred(ifilter.Current))
							yield return isrc.Current;
		}
	}

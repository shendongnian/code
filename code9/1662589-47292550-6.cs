    public static IEnumerable<T> Interleave<T>(this IEnumerable<T> first, IEnumerable<T> second)
	{
		using (var firstEnumerator = first.GetEnumerator())
		using (var secondEnumerator = second.GetEnumerator())
        {
		    var firstMoved = firstEnumerator.MoveNext();
		    var secondMoved = secondEnumerator.MoveNext();
		    while (firstMoved || secondMoved)
		    {
			    if (firstMoved)
				    yield return firstEnumerator.Current;
			    if (secondMoved)
				    yield return secondEnumerator.Current;
			    firstMoved = firstEnumerator.MoveNext();
			    secondMoved = secondEnumerator.MoveNext();
            }
		}
	}

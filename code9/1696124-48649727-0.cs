    public static class LinqEx
    {
    	public static bool IsSubsequenceOf<T>(
            this IEnumerable<T> subSequence, 
            IEnumerable<T> sequence) where T : IEquatable<T>
    	{
    		var subSequenceIterator = subSequence.GetEnumerator();
    		if (!subSequenceIterator.MoveNext()) return true;
    		var started = false;
    		foreach (var superitem in sequence)
    		{
    			if (superitem.Equals(subSequenceIterator.Current))
    			{
    				started = true;
    				if (!subSequenceIterator.MoveNext()) return true;
    			}
    			else if (started)
    			{
    				return false;
    			}
    		}
    		return false;
    	}
    }

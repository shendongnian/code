    public IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> input, T splitOn)
    {
    	var l = new List<T>();
    	foreach (var item in input)
    	{
    		if(object.Equals(item, splitOn))
    		{
    			yield return l;
    			l = new List<T>();
    		}
    		else
    			l.Add(item);
    	}
    	yield return l;
    }

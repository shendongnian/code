    public static IEnumerable<List<T>> SplitArray<T>(T[] arr, int splitsNumber)
    {
    	var list = arr.ToList();
    	int size = list.Count / splitsNumber;
    	int pos = 0;
    	for (int i = 0; i + 1 < splitsNumber; ++i, pos += size)
    	{
    		yield return list.GetRange(pos, size);
    	}
    
    	yield return list.GetRange(pos, list.Count - pos);
    }

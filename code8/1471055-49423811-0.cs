    /// <summary>
    /// Removes all occurrences of the specified collection from the referenced array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="collection"></param>
    public static void RemoveAll<T>(ref T[] array, T[] collection)
    {
    	T[] result = { };
    
    	for (int i = 0; i < array.Length; i++)
    	{
    		T[] chunk = new T[collection.Length];
    
    		for (int j = 0; j < chunk.Length; j++)
    			if (!((i + j) >= array.Length))
    				chunk[j] = array[i + j];
    
    		bool match = true;
    		for (int j = 0; j < chunk.Length; j++) { if (!Equals(chunk[j], collection[j])) { match = false; break; } }
    
    
    		if (!match) {
    			Array.Resize(ref result, result.Length + 1);
    			result[result.Length - 1] = chunk[0];
    		}
    		else i += collection.Length - 1;
    	}
    
    	array = result;
    }

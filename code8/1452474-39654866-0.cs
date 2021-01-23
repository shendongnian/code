    internal class GenericListComparer<T>
    {
    	internal static bool Compare(List<T> firstCollection, List<T> secondCollection)
    	{
    		return firstCollection.TrueForAll(secondCollection.Contains) &&
    			   secondCollection.TrueForAll(firstCollection.Contains);
    	}
    }

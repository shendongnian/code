    public static class EnumerableExtensions
    {
    	public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
    	{
    		var queue = new Queue<T>(count);
    		if (source == null)
    		{
    			yield break;
    		}
    		foreach (var item in source)
    		{
    			if (queue.Count == count)
    			{
    				queue.Dequeue();
    			}
    			queue.Enqueue(item);
    		}
    		foreach (var item in queue)
    		{
    			yield return item;
    		}
    	}
    }

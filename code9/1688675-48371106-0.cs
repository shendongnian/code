	const int partitionSize = 2;
	var itemLookup = items.ToLookup(x => x.Split(',')[0], x => Int32.Parse(x.Split(',')[1]));
	var partitionedItems = itemLookup.Partition(partitionSize);
    foreach (var partition in partitionedItems)
	foreach (var lookup in partition)
	{
		Console.WriteLine("Key: " + lookup.Key);
		Console.WriteLine("Values: ");
		foreach (var i in lookup.ToList())
		{
			Console.WriteLine(i);
		}
	}
    public static class PartitionExtensions
    {
    	public static IList<ILookup<K, V>> Partition<K, V>(this ILookup<K, V> lookup, int size)
    	{
    		return lookup.SelectMany(l => l.ToList().Partition(size).Select(p => p.ToLookup(x => l.Key, x => x))).ToList();
    	}
    
    	public static IList<IList<T>> Partition<T>(this IList<T> list, int size)
    	{
    		IList<IList<T>> results = new List<IList<T>>();
    		var itemCount = list.Count();
    		var partitionCount = itemCount / size;
    		
    		//your paritioning method is truncating items that don't make up a full partition
    		//if you want the remaining items in a partial partition, use this code instead
    		//var partitionCount = ((itemCount % size == 0) ? itemCount : itemCount + size) / size;
    		
    		for (var i = 0; i < partitionCount; i++)
    		{
    			results.Add(list.Skip(i * size).Take(size).ToList());
    		}
    		
    		return results;
    	}
    }

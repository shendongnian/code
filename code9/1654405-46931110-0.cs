    private static readonly Random Random = new Random();
    private static readonly object Sync = new object();
    
    public static IEnumerable<T> RandomElement<T>(this IEnumerable<T> enumerable, int amount)
    {
        if (enumerable == null)
            throw new ArgumentNullException(nameof(enumerable));
    
        var count = enumerable.Count();
    
        int ndx;
        lock (Sync)
            ndx = Random.Next(count); // returns non-negative number less than max
    
		return enumerable.Skip(ndx - amount).Take(amount);
    }

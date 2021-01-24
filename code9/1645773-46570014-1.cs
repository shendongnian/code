    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int parts) 
    {
        var list = new List<T>(source);    
        foreach (var group in list.GroupBy(x => list.IndexOf(x) % parts)) 
        {
            yield return group.ToList();
        }
    }

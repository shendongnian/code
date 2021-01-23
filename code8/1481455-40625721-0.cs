    public static List<T> Except<T>(List<T> a, List<T> b)
    {
        var hash = new HashSet<T>(b);
        var results = new List<T>(a.Count);
        foreach (var item in a)
        {
            if (!hash.Contains(item))
            {
                results.Add(item);
            }
        }
        return results;
    }

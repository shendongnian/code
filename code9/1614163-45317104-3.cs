    public static IEnumerable<T> AddRangeLazily<T>(this ICollection<T> col, IEnumerable<T> values)
    {
        foreach (T i in values)
        {
            yield return i; // first we yield
            col.Add(i); // then we add
        }
    }

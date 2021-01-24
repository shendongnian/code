    public static IEnumerable<T> AddRange<T>(this ICollection<T> col, IEnumerable<T> values)
    {
        foreach (int i in values)
        {
            col.Add(i);
            yield return i;
        }
    }

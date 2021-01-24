    public static int Count(this IEnumerable source)
    {
        var col = source as ICollection;
        if (col != null)
            return col.Count;
    
        int c = 0;
        using (var e = source.GetEnumerator())
        {
            while (e.MoveNext())
                c++;
        }
        return c;
    }

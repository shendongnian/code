    public static IEnumerable<T> Merge<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        // null-check here
        var enumerator1 = source1.GetEnumerator();
        var enumerator2 = source2.GetEnumerator();
        bool hasItem1, hasItem2;
        do
        {
            if (hasItem1 = enumerator1.MoveNext()) yield return enumerator1.Current;
            if (hasItem2 = enumerator2.MoveNext()) yield return enumerator2.Current;
        }
        while (hasItem1 || hasItem2);
    }

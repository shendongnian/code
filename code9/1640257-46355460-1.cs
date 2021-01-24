    public static IEnumerable<string> Merge<T(
        this IEnumerable<string> first,
        IEnumerable<string> second,
        IEnumerable<string> third)
    {        
        using (var eFirst = first.GetEnumerator())
        using (var eSecond = second.GetEnumerator())
        using (var eThird = third.GetEnumerator())
        {
            while (eFirst.MoveNext() && eSecond.MoveNext() && eThird.MoveNext())
            {
                var values = new[] { eFirst.Current, eSecond.Current, eThird.Current };
                yield return values.Where(value => string.IsNullOrEmpty(value) == false)
                                   .DefaultIfEmpty("")
                                   .First();
            }
        }
    }

    public static IEnumerable<string> Merge<T(
        this IEnumerable<string> first,
        IEnumerable<string> second,
        IEnumerable<string> third)
    {        
        using (var eFirst = first.GetEnumerator())
        using (var eSecond = second.GetEnumerator())
        using (var eThird = third.GetEnumerator())
        {
            var values = new[] { eFirst.MoveNext(), eSecond.MoveNext(), eThird.MoveNext() };
            yield return values.Where(value => string.IsNullOrEmpty(value) == false)
                               .DefaultIfEmpty("")
                               .First();
        }
    }

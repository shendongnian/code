    IEnumerable<DateTime> DateRange(DateTime start, DateTime end, TimeSpan period)
    {
        for (var dt = start; dt <= end; dt = dt.Add(period))
        {
            yield return dt;
        }
    }
----
    public static IEnumerable<IEnumerable<T>> GroupSequenceWhile<T>(this IEnumerable<T> seq, Func<T, T, bool> condition) 
    {
        List<T> list = new List<T>();
        using (var en = seq.GetEnumerator())
        {
            if (en.MoveNext())
            {
                var prev = en.Current;
                list.Add(en.Current);
                while (en.MoveNext())
                {
                    if (condition(prev, en.Current))
                    {
                        list.Add(en.Current);
                    }
                    else
                    {
                        yield return list;
                        list = new List<T>();
                        list.Add(en.Current);
                    }
                    prev = en.Current;
                }
                if (list.Any())
                    yield return list;
            }
        }
    }

    static IEnumerable<TResult> ZipNull<T1, T2, TResult>(this IEnumerable<T1> a, IEnumerable<T2> b, Func<T1?, T2?, TResult> func)
        where T1 : struct
        where T2 : struct
    {
        using (var it1 = a.GetEnumerator())
        using (var it2 = b.GetEnumerator())
        {
            while (true)
            {
                if (it1.MoveNext())
                {
                    if (it2.MoveNext())
                    {
                        yield return func(it1.Current, it2.Current);
                    }
                    else
                    {
                        yield return func(it1.Current, null);
                    }
                }
                else
                {
                    if (it2.MoveNext())
                    {
                        yield return func(null, it2.Current);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

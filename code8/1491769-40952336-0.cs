    public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> seq, 
                                                            Func<T, bool> condition)
    {
        List<T> list = new List<T>();
        using (var en = seq.GetEnumerator())
        {
            if (en.MoveNext())
            {
                list.Add(en.Current);
                while (en.MoveNext())
                {
                    if (condition(en.Current))
                    {
                        list.Add(en.Current);
                    }
                    else
                    {
                        yield return list;
                        list = new List<T>();
                    }
                }
                if (list.Any())
                    yield return list;
            }
        }
    }

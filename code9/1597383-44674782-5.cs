    public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> source, T separator,bool include=false)
    {
        List<T> result=new List<T>(3);
        foreach(T item in source)
        {
            if (item == separator)
            {
                if (include) result.Add(item);
                yield return result;
                result=new List<T>(3);
            }
            else 
            {
                result.Add(item);
            }
        }
        yield return result;
    }

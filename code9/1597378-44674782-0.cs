    public static IEnumerable<List<T>> Split<T>(tihs IEnumerable<T> source, T separator)
    {
        List<T> result=new List<T>(3);
        foreach(T item in source)
        {
            if (item==separator)
            {
                yield return result;
                result=new List<T>(3);
            }
            else 
            {
                result.Add(item);
            }
        }
    }

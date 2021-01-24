    public static IEnumerable<T> AsSequence<T>(this T obj)
    {
        yield return obj;
    }  
...
    Set(Data.AsEnumerable().Last().AsSequence());

    public static IEnumerable<TResult> SelectWithNullCheck<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        return source.Select(x => 
                             {
                                 try
                                 {
                                     return selector(x);
                                 }
                                 catch(NullReferenceException ex)
                                 {
                                     return default(TResult); 
                                 }
                             })
                     .Where(x=> default(TResult) != x);
    }

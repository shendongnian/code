    public static IObservable<IList<TSource>> BufferWithClosingValue<TSource>(
        this IObservable<TSource> source, 
        TimeSpan maxTime, 
        TSource closingValue)
    {
        return source.GroupByUntil(_ => true,
                                   g => g.Where(i => i.Equals(closingValue)).Select(_ => Unit.Default)
                                         .Merge(Observable.Timer(maxTime).Select(_ => Unit.Default)))
                     .SelectMany(i => i.ToList());
    }

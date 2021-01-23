    public static IObservable<T> RateLimit<T>(this IObservable<T> source,
                                       TimeSpan minDelay)
    {
        var trueThenFalse = Enumerable.Repeat(true, 1).Concat(Inf(false));
        return
            source.TimeInterval()
                .Zip(trueThenFalse, (item, firstTime) => Observable.Return(item.Value)
                    .Delay(firstTime
                        ? TimeSpan.Zero
                        : TimeSpan.FromTicks(
                            Math.Max(minDelay.Ticks - item.Interval.Ticks, 0))))
                .Concat();
    }

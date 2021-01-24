    public static IEnumerable<IEnumerable<T>>
    Intervals<T, R>(this IEnumerable<T> Input, Func<T, R> f)
    where R : IEquatable<R>
    {
        if (0 != Input.Count())
        {
            var CurrentValue = f(Sequence.First());
            Func<T, bool> IntervalPredicate = iEl => f(iEl).Equals(CurrentValue);
            return new IEnumerable<T>[]
                   {Input.TakeWhile(IntervalPredicate)}
                   .Concat(Input.SkipWhile(IntervalPredicate).Intervals(f));
        }
        else
        {
            return Enumerable.Empty<IEnumerable<T>>();
        }
    }

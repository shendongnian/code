    public static IEnumerable<TResult> Scan<T, TResult>(this IEnumerable<T> src, TResult seed, Func<TResult, T, TResult> combine) {
        foreach (var s in src) {
            seed = combine(seed, s);
            yield return seed;
        }
    }
    public static IEnumerable<T> Compress<T>(this IEnumerable<bool> bv, IEnumerable<T> src) {
        var srce = src.GetEnumerator();
        foreach (var b in bv) {
            srce.MoveNext();
            if (b)
                yield return srce.Current;
        }
    }
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> rest, params T[] first) => first.Concat(rest);
    public static IEnumerable<T> Append<T>(this IEnumerable<T> rest, params T[] last) => rest.Concat(last);

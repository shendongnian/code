    public static IEnumerable<bool> And(this IEnumerable<bool> a, IEnumerable<bool> b) => a.Zip(b, (ab, bb) => ab && bb);
    public static IEnumerable<bool> Or(this IEnumerable<bool> a, IEnumerable<bool> b) => a.Zip(b, (ab, bb) => ab || bb);
    public static IEnumerable<bool> Not(this IEnumerable<bool> a) => a.Select(b => !b);
    public static IEnumerable<T> Leave<T>(this ICollection<T> src, int drop) => src.Take(src.Count - drop);
    public static IEnumerable<T> Leave<T>(this IEnumerable<T> src, int drop) {
        var esrc = src.GetEnumerator();
        var buf = new Queue<T>();
        while (drop-- > 0)
            if (esrc.MoveNext())
                buf.Enqueue(esrc.Current);
            else
                break;
        while (esrc.MoveNext()) {
            buf.Enqueue(esrc.Current);
            yield return buf.Dequeue();
        }
    }
    public static IEnumerable<T> Rotate<T>(this IEnumerable<T> src, int num) {
        if (num > 0) {
            var esrc = src.GetEnumerator();
            var q = new Queue<T>();
            while (esrc.MoveNext() && num-- > 0)
                q.Enqueue(esrc.Current);
            while (esrc.MoveNext())
                yield return esrc.Current;
            while (q.Count > 0)
                yield return q.Dequeue();
        }
    }
    public static IEnumerable<T> RightShift<T>(this IEnumerable<T> src, int num) {
        var lead = num;
        while (lead-- > 0)
            yield return default(T);
            
        foreach (var s in src.Leave(num))
            yield return s;
    }
    public static IEnumerable<T> LeftShift<T>(this IEnumerable<T> src, int num) {
        foreach (var s in src.Skip(num))
            yield return s;
        while (num-- > 0)
            yield return default(T);
    }
    public static IEnumerable<T> Compress<T>(this IEnumerable<bool> bv, IEnumerable<T> src) {
        var srce = src.GetEnumerator();
        foreach (var b in bv) {
            srce.MoveNext();
            if (b)
                yield return srce.Current;
        }
    }

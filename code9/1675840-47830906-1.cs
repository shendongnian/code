    public static bool HasSingle<T>(this IEnumerable<T> sequence) {
        if (sequence is ICollection<T> list) return list.Count == 1; // simple case
        using(var iter = sequence.GetEnumerator()) {
            return iter.MoveNext() && !iter.MoveNext();
        }
    }

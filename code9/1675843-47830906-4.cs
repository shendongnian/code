    public static bool HasSingle<T>(this IEnumerable<T> sequence, out T value)
    {
        if (sequence is IList<T> list)
        {
            if(list.Count == 1)
            {
                value = list[0];
                return true;
            }
        }
        else
        {
            using (var iter = sequence.GetEnumerator())
            {
                if (iter.MoveNext())
                {
                    value = iter.Current;
                    if (!iter.MoveNext()) return true;
                }
            }
        }
        value = default(T);
        return false;
    }

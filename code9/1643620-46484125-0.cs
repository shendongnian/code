    public static void Combine<T1, T2>(IEnumerable<T1> target, IEnumerable<T2> modifyier, Action<T1, T2> modify)
    {
        using (var seq1 = target.GetEnumerator())
        using (var seq2 = modifyier.GetEnumerator())
        {
            while (seq1.MoveNext() && seq2.MoveNext())
            {
                modify(seq1.Current, seq2.Current);
            }
        }
    }

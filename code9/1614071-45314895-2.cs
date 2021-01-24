    public static bool All<T>(this IEnumerable<T> seq, Func<T, int, bool> pred)
    {
        return seq.Select((x, i) => Tuple.Create(x, i)).All(t => pred(t.Item1, t.Item2));
    }
...
    IEnumerable<int> indices = lists
        .Where(list => list.All((s, i) => s == null || domains[i].Contains(s)))
        .Select(list => list.Select((s, i) => s == null ? 0 : 1 << i).Sum())
        .Distinct();

    public static int[] processFunc(int[] scores, int[] l, int[] r)
    {
        var min = Math.Min(l.Min(z => z), r.Min(z => z));
        var max = Math.Max(l.Max(z => z), r.Max(z => z));
        var grouped = scores.Where(z => z >= min && z <= max).GroupBy(z => z).Select(val => Tuple.Create(val.Key, val.Count())).OrderBy(z => z.Item1).ToList();
        return l.Zip(r, (left, right) =>
        {
            var matching = grouped.Where(z => z.Item1 >= left).TakeWhile(z => z.Item1 <= right);
            return matching.Sum(z => z.Item2);
        }).ToArray();
    }

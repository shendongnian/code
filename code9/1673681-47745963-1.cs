    public static int[] processFunc(int[] scores, int[] l, int[] r)
    {
        HashSet<int> lAndR = new HashSet<int>(l);
        foreach (var i in r)
        {
            lAndR.Add(i);
        }
        var grouped = scores.Where(z => lAndR.Contains(z)).GroupBy(z => z).ToDictionary(val => val.Key, val => val.Count());
        return l.Zip(r, (left, right) =>
        {
            int sum1, sum2 = 0;
            grouped.TryGetValue(left, out sum1);
            grouped.TryGetValue(right, out sum2);
            return sum1 + sum2;
        }).ToArray();
    }

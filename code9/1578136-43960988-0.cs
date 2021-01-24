    static IEnumerable<List<T>> MultiCombinations<T>(List<T> multiset, int min, int max)
    {
        Debug.Assert(min >= 0 && max >= 0);
        var a = multiset.OrderBy(x => x).ToList();
        max = Math.Min(max, a.Count);
        if (min <= max)
            foreach (var combo in Combine(a, min, max, 0, new List<T>()))
                yield return combo;
    }
    private static IEnumerable<List<T>> Combine<T>(List<T> a, int min, int max, int i, List<T> combo)
    {
        if (i < a.Count && combo.Count < max)
        {
            combo.Add(a[i]);
            foreach (var c in Combine(a, min, max, i + 1, combo))
                yield return c;
            combo.RemoveAt(combo.Count - 1);
            var j = IndexOfNextUniqueItem(a, i);
            foreach (var c in Combine(a, min, max, j, combo))
                yield return c;
        }
        else if (combo.Count >= min)
        {
            Debug.Assert(combo.Count <= max);
            yield return new List<T>(combo);
        }
    }
    private static int IndexOfNextUniqueItem<T>(List<T> a, int i)
    {
        int j = i + 1;
        while (j < a.Count && a[j].Equals(a[i]))
            j++;
        return j;
    }

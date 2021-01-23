    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
    {
        return new HashSet<T>(items);
    }
    var keys = list2.Select(i => new { i.Name, i.Number }).ToHashSet();
    var toadd = list1.GroupBy(i => new { i.Name, i.Number })
                     .Where(g => !keys.Contains(g.Key))
                     .Select(g => g.First());
    list2.AddRange(toadd);

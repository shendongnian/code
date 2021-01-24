    private static IEnumerable<string> Distinct(IEnumerable<string> values)
    {
        var list = new List<string>();
        list.AddRange(values.Where(x => !list.Contains(x)));
        return list;
    }

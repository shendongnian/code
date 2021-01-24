    IEnumerable<Tuple<string, string[]>> splittedItems =
        items.Select(i => new Tuple<string, string[]>(i, Regex.Split(i, "([0-9]+)")));
    List<string> orderedItems = splittedItems.OrderBy(t => Convert.ToInt16(t.Item2[1]))
        .ThenBy(t => t.Item2.Length > 1 ? t.Item2[2] : "1")
        .Select(t => t.Item1).ToList();

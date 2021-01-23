    public static IQueryable<MyClass> Filter(this IQueryable<MyClass> items, string machineQuery, string actionQuery, string partQuery)
    {
        if (!String.IsNullOrWhiteSpace(machineQuery)
            items = items.Where(i => i.Machine.Contains(machineQuery);
        if (!String.IsNullOrWhiteSpace(actionQuery)
            items = items.Where(i => i.Action.Contains(actionQuery);
        if (!String.IsNullOrWhiteSpace(partQuery)
            items = items.Where(i => i.Part.Contains(partQuery);
        return items;
    }

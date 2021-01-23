    public IQueryable<MyClass> Filter(this IQueryable<MyClass> items, string machineQuery, string actionQuery, string partQuery)
    {
        if (!String.IsNullOrWhitespace(machineQuery)
            items = items.Where(i => i.Machine.Contains(machineQuery);
        if (!String.IsNullOrWhitespace(actionQuery)
            items = items.Where(i => i.Action.Contains(actionQuery);
        if (!String.IsNullOrWhitespace(partQuery)
            items = items.Where(i => i.Part.Contains(partQuery);
        return items;
    }

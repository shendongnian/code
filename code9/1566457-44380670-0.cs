    // First query
    var testEntityAs = context.TestEntityAs.ToList();
    var testEntityAsIds = testEntityAs.Select(t => t.Id);
    // Second query, can apply filter of Hello World without loading all TestEntityBs
    context.TestEntityBs
        .Where(t => testEntityAsIds.Contains(t.Id) && t.Property == "Hello World")
        .Load();
    // In memory check
    var isAny = testEntityAs.Any(t => !string.IsNullOrEmpty(t.BProperty));

    SWOT = vm.Swots
        .Include(x => x.ExternalSwotParts)
        .Include(x => x.InternalSwotParts)
        .Where(...)
        .ToArray()
        .Select(x => new SWOT
    {
        SwotForId = x.SwotForId,
        SwotParts = x.ExternalSwotParts.Select(y => new SwotPart
        {
            SwotTypeId = y.SwotTypeId,
            Label = y.Label
        }).ToList(),
        InternalSwotParts = x.InternalSwotParts.Select(z => new SwotPart
        {
            SwotTypeId = z.SwotTypeId,
            Label = z.Label
        }).ToList()
    }).ToList()

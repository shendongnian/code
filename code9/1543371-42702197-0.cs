    SWOT = vm.Swots.Select(x => new SWOT
    {
        SwotForId = x.SwotForId,
        SwotParts = x.ExternalSwotParts.Select(y => new SwotPart
        {
            SwotTypeId = y.SwotTypeId,
            Label = y.Label
        }).Concat(
        x.InternalSwotParts.Select(z => new SwotPart
        {
            SwotTypeId = z.SwotTypeId,
            Label = z.Label
        })).ToList()       
    }).ToList()

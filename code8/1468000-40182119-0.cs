    var pallets = GetPalletNumbers()
        .GroupBy(p => p.dropno)
        .Select(g => new
        {
            DropGroup = g.Key,
            Pallets = g.OrderBy(p => p.palletstatus == "Full" ? 1 
                                   : p.palletstatus == "Partial" ? 2 
                                   : 3) //weights
                       .Select((p, i) => { p.palletno = i + 1; return p; })
                       // would be better to create a new object versus mutate but this works
                       .ToList()
        })
        .ToList();

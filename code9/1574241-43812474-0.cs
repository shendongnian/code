    var somethings = db.Products.Select(s => new SomethingViewModel
    {
        Id = s.Id,
        Name = s.Name,
        IsActive = s.IsActive
        SubSomethings = s.SubSomethings.Select(ss => new PartViewModel
        {
            Id = ss.Id,
            Name = ss.Name,
            IsActive = ss.IsActive
        }).Where(wss => wss.IsActive)                        
    }).Where(ws => ws.IsActive && ws.SubSomethings.Any())
    .ToList();

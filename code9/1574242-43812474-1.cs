    var products = db.Products.Where(ws => ws.IsActive && ws.SubSomethings.Count(ss => ss.IsActive) > 0)
    .Select(p => new SomethingViewModel
    {
    	Id = p.Id,
        Name = p.Name,
        IsActive = p.IsActive,
    	SubSomethings = p.SubSomethings.Select(ss => new PartViewModel
        {
            Id = ss.Id,
            Name = ss.Name,
            IsActive = ss.IsActive
        }).Where(wss => wss.IsActive)   
    }).ToList();

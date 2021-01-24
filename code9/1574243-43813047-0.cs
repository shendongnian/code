    var somethings = db.Somethings
    	.Include("SubSomethings") // added this
    	.Select(s => new SomethingViewModel
    {
        Id = s.Id,
        Name = s.Name,
        IsActive = s.IsActive
        SubSomethings = s.SubSomethings.Select(ss => new SubSomethingViewModel
        {
            Id = ss.Id,
            Name = ss.Name,
            IsActive = ss.IsActive
        }).Where(wss => wss.IsActive)                        
    }).Where(ws => ws.IsActive)
    .ToList(); //this finishes very quickly
    
    var somethings2 = somethings.Where(s => s.SubSomethings.Any()).ToList(); //This is where the code bogged down

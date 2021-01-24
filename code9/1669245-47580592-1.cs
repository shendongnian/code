    var grouped = query.Group(
        key => key.Id,
        g => new 
        {
            Id = g.Key
        }).ToList(); 

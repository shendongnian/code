    var somethings = db.Somethings
    	.Include(s => s.SubSomethings)
    	.Where(s => s.IsActive)
    	.AsEnumerable()
    	.Select(s => new SomethingViewModel
    	{
    		Id = s.Id,
    		Name = s.Name,
    		IsActive = s.IsActive,
    		SubSomethings = s.SubSomethings.Select(ss => new SubSomethingViewModel
    		{
    			Id = ss.Id,
    			Name = ss.Name,
    			IsActive = ss.IsActive
    		}).Where(wss => wss.IsActive).ToList()
    	})
    	.Where(s => s.SubSomethings.Any())
    	.ToList();

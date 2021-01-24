    var appt = (from col1 in collection1.AsQueryable()
    	join col2 in collection2.AsQueryable() on col1.Id equals col2.RefKey into grp
    	select new
    	{
    		col1.Id,
    		col1.BandId,
    		filteredCol = col1.BandId == "" ? grp : grp.Where(t => t.Name == "Hello")
    	}).Take(10).ToList();

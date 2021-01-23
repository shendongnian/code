	IQueryable<PhraseCategory> query = db.PhraseCategories;
	// Order as needed
	if(param == "s")
		query = query.OrderBy(m => m.SortOrder);
	else if(param == "n")
		query = query.OrderBy(m => m.Name);
		
	var result = query
		.Select(p => new
		{
		 Id = p.PhraseCategoryShortId,
		 Name = p.Name
		})
		.AsNoTracking()
		.ToListAsync();		
	return Ok(result);

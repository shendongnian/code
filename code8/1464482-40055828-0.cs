    var searchResult = db.bazar.Include(c => c.images).AsQueryable();
    if(search != null){
    	searchResult = searchResult.Where(da => da.BAZAR_TEXT.Contains(search));
    }
    
    if(category != null){
    	searchResult = searchResult.Where(x => x.CATEGORY == category);
    }
    
    if(county != null){
    	searchResult = searchResult.Where(x => x.DISTRICT == county);
    }
    
    if(priceFrom != null){
    	searchResult = searchResult.Where(x => x.PRICE  == priceFrom);
    }
    
    if(priceUntil != null){
    	searchResult = searchResult.Where(x => x.PRICE  <= priceUntil);
    }
    
    
    return View(searchResult.ToList().ToPagedList(page ?? 1, 10));

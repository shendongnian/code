    WebEntities db = new WebEntities();
                var searchResult = db.bazar.Include(c => c.images);
                if (!string.IsNullOrEmpty(search))
                {
                    searchResult = searchResult.Where(da => da.BAZAR_TEXT.Contains(search));
                }
    
                if (!string.IsNullOrEmpty(category))
                {
                    searchResult = searchResult.Where(x => x.CATEGORY == category);
                }
    
                if (!string.IsNullOrEmpty(county))
                {
                    searchResult = searchResult.Where(x => x.DISTRICT == county);
                }
    
                if (priceFrom != null)
                {
                    searchResult = searchResult.Where(x => x.PRICE >= priceFrom);
                }
    
                if (priceUntil != null)
                {
                    searchResult = searchResult.Where(x => x.PRICE <= priceUntil);
                }
    
    
                return View(searchResult.ToList().ToPagedList(page ?? 1, 10));

     public virtual async Task<ActionResult> Categories()
        {
            var items = await _categoryService.GetAll()
                .Include(x => x.CategoryPictures)
                .Include(x => x.CategoryListingTypes)
                .Include(x => x.Listings)
                .Include(x => x.CategoryStats)
                .ToListAsync();
    
            
    
            return View(items);
        }

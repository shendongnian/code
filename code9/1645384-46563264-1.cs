	public ActionResult List(string category, string search, int page = 1)
	{
		var model = new ProductsListViewModel();
		var query = repository.Products;
                    
    
		if (!String.IsNullOrEmpty(category))
		{
			query = query.Where(p => p.Category == category);
			model.CurrentCategory = category;
		}
		
		if (!String.IsNullOrEmpty(search))
		{
			query = query.Where(p => p.Description.Contains(search));
			model.Search = search;
		}
		
		var count = query.Count();
		
		model.Products = query
						.OrderByDescending(p => p.ProductID)
						.Skip((page - 1) * PageSize)
						.Take(PageSize).ToList();
	
		model.PagingInfo = new PagingInfo()
					{
						CurrentPage = page,
						ItemsPerPage = PageSize,
						TotalItems = count
					};
					
		return View(model);
	}

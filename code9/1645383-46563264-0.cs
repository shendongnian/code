    var query = repository.Products
                    .Where(p => category == null || p.Category == category);
    
    if(!string.IsNullOrEmpty(search))
         query = query.Where(p => p.Description.Contains(search))
    
    Products = query
                    .OrderByDescending(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null?
                    repository.Products.Count():
                    repository.Products.Where(e =>
                         e.Category == category).Count()
                 },
                CurrentCategory = category
                

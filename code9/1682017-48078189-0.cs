    var VMCategories = _context.ProductCategories
        .Include(e => e.Children)
        .OrderBy(s => s.SortOrder)
        .Where(r => r.ParentId == null) // only need root level categories in the View
        .Select(v => new ViewModelProductCategory
        {
            Id = v.Id,
            Children = v.Children, // Select it
            ParentId = v.ParentId,
            Title = v.Title,
            SortOrder = v.SortOrder,
            // get products without a category:
            OrphanProducts = v.ProductInCategory
                .Where(o => !_context.ProductsInCategories.Any(pc => o.Id == pc.ProductId))
                .Select(orph => new ViewModelProduct
                {
                    Id = orph.Product.Id,
                    Title = orph.Product.Title,
                    Price = orph.Product.Price,
                    Info = orph.Product.Info,
                    SortOrder = orph.SortOrder
                })
                .OrderBy(s => s.SortOrder)
                .ToList()
    
        })
        .ToList();

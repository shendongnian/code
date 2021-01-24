    var products = _context.ProductCategories
        .Select(category => new ViewModelProductCategory
        {
            Id = category.Id,
            ParentId = category.ParentId,
            Title = category.Title,
            SortOrder = category.SortOrder,
            NumOfProducts = category.ProductInCategory.Count()
            Products = category.ProductInCategory
                .Select(pic => new ViewModelProduct
                {
                    Id = pic.Product.Id,
                    Title = pic.Product.Title,
                    Price = pic.Product.Price,
                    Info = pic.Product.Info
                }
                .ToList();
        }).ToList();

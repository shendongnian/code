      var product = (from p in _context.Products
                  where p.Id == id
                  select new ViewModelProduct
                  {
                    Id = p.Id,
                    Title = p.Title,
                    Info = p.Info,
                    Price = p.Price,
                    Categories = p.InCategories.Select(
                      inCategory=> inCategory.ProductCategory)
                  }).SingleOrDefaultAsync();

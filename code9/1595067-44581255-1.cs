        var data = from p in _context.Product
            join o in _context.Order on p.Id equals o.ProductId into orderTemp
            from ord in orderTemp.DefaultIfEmpty()
            group ord by p into gp
            select new
            {
                Id = gp.Key.Id,                                        
                Price = gp.Key.Price,
                CategoryId = gp.Key.CategoryId,
                Rate = gp.Average(m => m == null ? 0 : m.Rate)
            };

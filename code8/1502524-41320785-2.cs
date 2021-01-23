    var query = from p in context.Product
                          .Include(x => x.Type)
                          .Include(x => x.Category)
                          .Include(x => x.WareHouse)
                          .Include(x => x.Photos);
    if (deleg != null)
    {
        query = query.Where(deleg);
    }
    query = from product in query
            join f in context.Favorite on product.Id equals f.ProductFid into fg
            from fgi in fg.Where(f => f.UserFid == userId).DefaultIfEmpty();
            orderby product.Id descending
            select new ProductngDto()
            {
                ProductItem = product,
                FavoriteId = fgi != null ? fgi.Id : (long?)null
            }).Skip(page * pageSize).Take(pageSize);

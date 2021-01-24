    IList<ProductResponse> response = myContext.Set<Product>()
        .Include( e => e.ProductAttributes )
        .Where( e => e.Id == 21098 )
        .Select( e => new ProductResponse {
            Id = e.Id,
            Name = e.Name,
            Attributes = e.ProductAttributes.ToDictionary( e => e.Key, e => e.Value ),
        } )
        .ToList();

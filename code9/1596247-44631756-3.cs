    public static Category WithProduct(this Category category, int id, string product)
    {
        category.Products.Add(new Product { Id = id, Name = name, CategoryId = category.Id });
        return category;
    }
    
    public static Category WithProduct(this Category category, Product product)
    {
        product.CategoryId = category.Id;
        category.Products.Add(product);
        return category;
    }
    public static Category WithProducts(this Category category, params Product[] products)
    {
        foreach(var product in products)
        {
            product.CategoryId = category.Id;
            category.Products.Add(product);
        };
        return category;
    }

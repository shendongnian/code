    public ProductRepository(ProductContext context)
    {
        _context = context;
        var group = _context.Group.Find(1);
        if (group.Products == null)
            group.Products = new List<Product>();
        if (_context.Reg.Count() == 0)
           group.Products.Add(new Product { productName = "Test" });
    }

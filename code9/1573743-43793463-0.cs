    var prods = _context.Products.Select(pr => new ProductViewModel
        {
            Id = pr.Id,
            Name = pr.Name
        }).ToList();
    
        var parts = _context.Parts.Select(prt => new PartViewModel
        {
            Id = prt.Id,
    	ProductId = prt.ProductId,
            Name = prt.Name
        }).ToList();
    
    
    prods.ForEach( pr => pr.Parts = parts.Where(prt=> prt.ProductId == pr.Id).ToList())

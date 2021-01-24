    prods = db.Products.Where(pr => pr.Parts.Any(p => p.SomeCategoryId == 200)).OrderBy(o => o.Name).Select(pr => new ProductViewModel
    {
        Id = pr.Id,
        Name = pr.Name,
        Parts = pr.Parts.OrderBy(o => o.Name).Select(prt => new PartViewModel
        {
            Id = prt.Id,
            Name = prt.Name,
            SomeCategoryId = prt.SomeCategoryId
        }).Where(w => w.SomeCategoryId == 200).ToList()
    }).ToList();
    
   

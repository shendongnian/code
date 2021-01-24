    public async Task<IActionResult> Index()
    {
        var allProducts = await _context.tblProducts.ToListAsync();
        var model = new Models.IndexViewModel();
        model.Product1List = allProducts.Where(x => x.ID == 1);
        model.Product2List = allProducts.Where(x => x.ID == 2);
        model.Product3List = allProducts.Where(x => x.ID == 3);
        //etc...
        return View(model);
    }

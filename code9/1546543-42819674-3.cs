    public async Task<IActionResult> Index()
    {
        var allProducts = await _context.tblProducts.ToListAsync();
        var model = new Models.IndexViewModel();
        model.Product1List = allProducts.Where(x => x.Product == "Apples");
        model.Product2List = allProducts.Where(x => x.Product == "Oranges");
        model.Product3List = allProducts.Where(x => x.Product == "Grapes");
        //etc...
        return View(model);
    }

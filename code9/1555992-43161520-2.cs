    [HttpGet]
    public IActionResult Create()
    {
        var categories = _repository.GetCategories().ToList();
        var categoriesModel = categories.Select(p => new
        {
            p.Id,
            p.Name
        });
        ViewBag.Categories = new SelectList(categoriesModel, "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult Create(ProductViewModel model)
    {
        // Save the image to desired location and retrieve the path
        // string ImagePath = ...        
        // Add to db
        _repository.Add(new Product
        {
            Id = model.Id,
            ImagePath = ImagePath,
            // and so on
        });
        return View();
    }

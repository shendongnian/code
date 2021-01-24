    var model = db.Category.Where(x => x.Category != "")
        .GroupBy(x => x.Category).Select(x => new CategoryVM
        {
            Name = x.Key,
            SubCategories = x.Select(y => y.Subcategory)
        });
    return View(model);

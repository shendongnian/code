    var vm = new ProductEditViewModel()
    {
        Id = product.Id,
        Name = product.Name,
        Categories = new List<CategoryViewModel>()
        {
            new CategoryViewModel() { Name = "Category 1", Value = "category1",
             IsSelected = productCategories.Where(c => c.Value == "category1").Count() > 0 ? true : false},
             //do the same
            //new CategoryViewModel() { Name = "Category 2", Value = "category2" },
            //new CategoryViewModel() { Name = "Category 3", Value = "category3" }
        },
        //not required
        //SelectedCategoryValues = productCategories.Select(c => c.Value).ToList()
    };
    return View(vm);

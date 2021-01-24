    [HttpGet]
    public ActionResult BlogCategories()
    {
            // var model = _categoryRepository.GetCategoryList().Select(x => new CategoryViewModel() { CategoryId=x.CategoryId,CategoryName=x.CategoryName,CategorySlug=x.CategorySlug }).ToList();
            var categoryList = _categoryRepository.GetCategoryList();
    
            var model = new List<CategoryViewModel>();
            foreach (var itm in categoryList)
            {
            model.Add(new CategoryViewModel() {CategoryId=itm.CategoryId,CategoryName=itm.CategoryName, CategorySlug=itm.CategorySlug, CategoryPostCount=_categoryRepository.GetPostCountForCategory(itm.CategoryId) });
            }
            return PartialView("BlogCategories",model);
    }

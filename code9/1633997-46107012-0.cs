    var categories = db.Categories.AsNoTracking()
        .Where(c => c.WebsiteId == websiteId)
        .ToList();
       
    foreach (var category in categories.Where(c => c.ParentCategoryId.HasValue))
    {
        categories.First(c => c.CategoryId == category.ParentCategoryId.Value).SubCategories.Add(category);
    }
    
    categories.RemoveAll(c => c.ParentCategoryId.HasValue);
    // categories is now a list of top level categories with deeply-nested sub-categories
 

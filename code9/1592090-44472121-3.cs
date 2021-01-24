    var category = new Category
    {
       Code = 1,
       SubCategories = new List<SubCategory>{new SubCategory{SubCode = 1}}
    }
    
    dbContext.Categories.Add(category);
    dbContext.SaveChanges();

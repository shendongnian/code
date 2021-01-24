    var categoryEntity = context.CategoryEntities.Find(category.Id);
    if(categoryEntity == null)
    {
        categoryEntity = new CategoryEntity()
        {
            Id = category.Id,
            CategoryName = category.CategoryName
        };
        context.CategoryEntities.Add(categoryEntity);
    }
    // same approach for other entities

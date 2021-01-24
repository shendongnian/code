    var categoryEntity = context.CategoryEntities.Find(category.Id) ?? new CategoryEntity()
    {
        Id = category.Id,
        CategoryName = category.CategoryName
    };
    var colorEntity = context.ColorEntities.Find(color.Id) ?? new ColorEntity()
    {
        Id = color.Id,
        ColorName = color.ColorName
    };
    var sizeEntity = context.SizeEntities.Find(size.Id) ?? new SizeEntity()
    {
        Id = size.Id,
        SizeName = size.SizeName
    };

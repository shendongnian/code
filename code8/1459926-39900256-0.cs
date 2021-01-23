    var query = context.Category;
    var categoriesStats = new
    {
        active = query.Count(t => t.IsActive),
        inactive = query.Count(t => !t.IsActive)
    };

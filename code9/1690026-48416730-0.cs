    public class CategoryNew: UidName
    {
        public IEnumerable<CategoryNew> ChildCategories { get; set; } = new List<CategoryNew>();
        public IEnumerable<UidName> Products { get; set; } = new List<UidName>();
    }
    
    public class UidName
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public bool? IsDeleted { get; set; }
    }
    // first run to create products
    var newProducts = products.Select(p => new UidName {
        Uid = p.Id,
        Name = p.Name,
        NameEnd = p.NameEng
    }).ToArray();
    // second run to create categories with products
    var newCategories = categories.Select(c => new CategoryNew {
        Uid = c.Id,
        Name = c.Name,
        NameEng = c.NameEng,
        IsDeleted = (bool?)null,  //TODO
        Products = newProducts.Where(p => c.ProductIds.Contains(p.Uid))
                              .ToList()
    }).ToArray();
    // last run find sub categories
    foreach(var category in newCategories) {
        var oldCategory = categories.First(c => c.Id == category.Uid);
        category.ChildCategories = newCategories.Where(c => oldCategory.ChildCategoriesIds.Contains(c.Uid))
                                                .ToArray();
    }

    // LIST OF PRODUCTS IN RESULT SETS
    List<Product> products = new List<Product> {
        new Product() {Id = 1, ProductCategories = new List<ProductCategory>()}, 
        new Product() {Id = 2, ProductCategories = new List<ProductCategory>()}
    };
    // LIST OF ALL PRODUCTS AND THEIR CATEGORY TAXONOMIES
    List<ProductCategory> allProductCategories = new List<ProductCategory>
    {
        new ProductCategory() {ProductId = 1, CategoryUid = 101, ParentCategoryUid = 30},
        new ProductCategory() {ProductId = 1, CategoryUid = 30, ParentCategoryUid = 2},
        new ProductCategory() {ProductId = 1, CategoryUid = 2, ParentCategoryUid = 1},
        new ProductCategory() {ProductId = 3, CategoryUid = 101, ParentCategoryUid = 43},
        new ProductCategory() {ProductId = 3, CategoryUid = 43, ParentCategoryUid = 8},
        new ProductCategory() {ProductId = 3, CategoryUid = 8, ParentCategoryUid = 1}
    };
    
    // General logic going on here:
    // Add all ProductCategory where the ProductID is equal
    // to the Prdoduct.ID to the current Product.ProductCategories
    products.ForEach(pr=>
        allProductCategories.Where(pC=>
            pC.ProductId.Equals(pr.Id)).ToList().ForEach(pC=>
                pr.ProductCategories.Add(pC)));
    // products.ToList().ForEach(x=>Console.WriteLine(x.ProductCategories.Count));

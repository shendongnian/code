    public class Repository {
            private EFDbContext context = new EFDbContext();
    
            public IEnumerable<Product> Products {
                get {
                    return context.Products;
                }
            }
    }

    static class ProductExtensions {
        public static List<T> GetProducts<T>(this DbSet<T> source) where T : IProduct {
            var productQry =
                from product in products
                where product.Column1 == "Example"
                select product;
            return productQry.ToList();
        }
    }

    static class ProductExtensions {
        public static List<T> GetProducts<T>(this DbSet<T> products)
            where T : IProduct {
            var productQry =
                from product in products
                where product.Column1 == "Example"
                select product;
            return productQry.ToList();
        }
    }

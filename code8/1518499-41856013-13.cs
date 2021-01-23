    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                var image = new Image();
                var product = new Product();
                var brand = new Brand();
                product.Image = image;
                product.Brand = brand;
                brand.Image = new Image();
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }

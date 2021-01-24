    public class ProductMongoRepository : IProductRepository
    {
        public ICollection<Product> SearchBySkuValue(string sku)
        {
            return ProductsMongoDatabase.Instance.GetEntityList<Product>();
        }
        public Product GetBySku(Sku sku)
        {
            var collection = ProductsMongoDatabase.Instance.GetCollection<Product>();
            return collection.Find(x => x.Sku.Equals(sku)).First();
        }
        public void SaveAll(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Save(product);
            }
        }
        public void Save(Product product)
        {
            var collection = ProductsMongoDatabase.Instance.GetCollection<Product>();
            collection
                .ReplaceOneAsync(
                    x => x.Sku.Equals(product.Sku), 
                    product,
                    new UpdateOptions() { IsUpsert = true })
                .Wait();
        }
    }

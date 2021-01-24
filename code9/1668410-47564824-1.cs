    public class ProductService : StatefulService, IProductService
        {
    
            public async Task AddProduct(Product product)
            {
                var products = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, Product>>("products");
    
                using (var tx = StateManager.CreateTransaction())
                {
                    await products.AddOrUpdateAsync(tx, product.Id, product, (id, value) => product);
    
                    await tx.CommitAsync();
                }
            }
    ...........
    }

    public MyProductDao
    {
      private readonly ICache _cache;
      public MyProductDao(ICache cache)
      {
        _cache = cache;
      }
      public List<MyProduct> GetProductsByCategory(int categoryId)
      {
        /* check if data available in cache to avoid pulling database */
        _cache.DoWhatever()....
        using (var context = new myDbEntities())
        {
            var myproducts = context.ProductEntities.Where(p => p.CategoryId == categoryId);
            return Mapper.Map<List<ProductEntity>, List<Product>>(products);
        }
      }

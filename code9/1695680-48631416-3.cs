    public IEnumerable<Product> GetAllProducts()
    {
         using(var context = factory.Create())
              yield return context.RetrieveAllProducts();
    }

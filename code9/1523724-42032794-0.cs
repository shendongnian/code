    interface IProduct
    {
    }
    public class Product : IProduct
    {
      public Product()
      {
        State = new ProductState();
      }
    
      internal Product(ProductState state)
      {
        State = state;
      }
    }
    public class ProductState: IProduct
    {
    
    }
    public class AgilePMContext : DbContext
    {
      public DbSet<ProductState> Products { get; set; }
    }

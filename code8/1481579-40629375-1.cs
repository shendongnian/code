      public interface IProductRepository:IGenericDataRepository<Product>
        {
               ////
        }
      public class     ProductRepository:GenericDataRepository<Product>,IProductRepository
        {
                 ////
        }
 

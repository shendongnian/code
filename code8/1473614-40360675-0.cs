        public class ProductsController : ODataController
            {
                ProductsContext db = new ProductsContext();
            
                [EnableQuery]
                public IQueryable<Product> Get()
                {
                   return db.Products;
                }         
          
                protected override void Dispose(bool disposing)
                {
                    db.Dispose();
                    base.Dispose(disposing);
                }
            }

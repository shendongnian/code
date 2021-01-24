      public class DataService : IDataService
        {
            ProductEntities context;
            public DataService()
            {
                context = new ProductEntities();
            }
            public BindingList<Product> ProductList
            {
                get
                {
                   //EDIT: YOU HAVE TO CALL context.Products.Load(); OR IT WILL RETURN EMPTY RESULTS
                   context.Products.Load();
                    return context.Products.Local.ToBindingList<Product>();
                }
            }
            public void SaveAll()
            {
                context.SaveChanges();
            }
        }

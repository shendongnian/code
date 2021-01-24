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
                    return context.Products.Local.ToBindingList<Product>();
                }
            }
            public void SaveAll()
            {
                context.SaveChanges();
            }
        }

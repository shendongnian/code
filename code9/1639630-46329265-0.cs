    public class DbContextFactory : IDbContextFactory
    {
       private List<Type> _contextTypes = new List<Type>{ typeof(CatContext), etc };
       public DbContext GetContext<T>() 
       {
          foreach (var t in _contextTypes)
          {
             var props = t.GetProperties();
             foreach (var prop in props) 
             {
                 //pseudo code
                 if (prop.PropertyType is DbSet<> && prop.GetGenericTypes()[0] == typeof(T)) 
                 {
                     return Activator.CreateInstance(t) as DbContext;
                 }
               
             }
          }
          return null;
        }
    }

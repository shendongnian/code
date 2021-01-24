        public abstract class Entity
        {
            public int Id { get; set; }
        }
    
        public class User:Entity
        {
            
            public string Name { get; set; }
        }
    
    
        public class Product:Entity
        {
            
            public string ProductName { get; set; }
        }
    
        public class ApplicationDBContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Product> Products { get; set; }
    
        }
    
        public class Repo<T> where T:Entity
        {
          
          public IList<T> GetList()
            {
                using (var context = new ApplicationDBContext())
                {
                   
                     return context.Set<T>().ToList();
                }
            }
            
        }

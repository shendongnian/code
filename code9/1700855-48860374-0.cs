     class BaseEntity {
       string Id {get; set;}
     }
    
     class Person : BaseEntity {
       string Name {get; set;}
     } 
    
     public static class DbContextExtensions
     {
        public static bool Exist<TModel>(this DbSet<TModel> model, string id) where TModel : BaseEntity
       {
          return !string.IsNullOrEmpty(id) && model.SingleOrDefault(x => x.Id == id) != null;
       }
     }

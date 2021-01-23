    public abstract class EntityBase 
    {
         public long Id {get; set;}
    }
    public class MyEntity : EntityBase
    {
     // Has Id!
    }
    public long Add(DbContext context, T entity) where T : EntityBase
    {
        var storedEntity = dbContext.Set<T>().Add(entity);
        dbContext.SaveChanges();
        return storedEntity.Id; // Will always have the property.
    }

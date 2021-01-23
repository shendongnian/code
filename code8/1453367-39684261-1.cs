    public abstract class EntityBase 
    {
         public virtual long Id {get; set;}
    }
    public class MyEntity : EntityBase
    {
        [Column("TableId"]
        public override long Id {get;set;}
    }
    public long Add(DbContext context, T entity) where T : EntityBase
    {
        var storedEntity = dbContext.Set<T>().Add(entity);
        dbContext.SaveChanges();
        return storedEntity.Id; // Will always have the property.
    }

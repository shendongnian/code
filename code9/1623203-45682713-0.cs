        internal class UtilityMethods<TEntity, Tid> where TEntity : class
        {
          public static bool InsertEntity(Entities dbContext, TEntity entity)
            {
                dbContext.Entry(entity).State = EntityState.Added;
                dbContext.Set<TEntity>().Add(entity);
    
                dbContext.SaveChanges();
    
                return true;
            }
        }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
     {   
    
        public int GetMaxPK(Func<TEntity, decimal> columnSelector)
        {
            var GetMaxId = db.Set<TEntity>().Max(columnSelector);
            return GetMaxId;
        }
     }

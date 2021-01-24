        public interface IRepository<TEntity> where TEntity : Entity
        {
            IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
    
            void Save(TEntity entity);
    
            void Delete(TEntity entity);
        }
    
        public abstract class EfRepository<T> : IRepository<T> where T : Entity
        {
            private readonly DbContext _dbContext;
            protected readonly DbSet<T> _dbSet;
            public EfRepository(YourDbContextContext dbContext)
            {
                _dbContext = dbContext;
                _dbSet = dbContext.Set<T>();
            }
    
            public void Delete(T entity)
            {
                if (entity == null) return;
                else
                {
                    DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
    
                    if (dbEntityEntry.State != EntityState.Deleted)
                    {
                        dbEntityEntry.State = EntityState.Deleted;
                    }
                    else
                    {
                        _dbSet.Attach(entity);
                        _dbSet.Remove(entity);
                        _dbContext.SaveChanges();
                    }
                }
            }
    
            public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
            {
                return _dbSet.Where(predicate);
            }
    
            public void Save(T entity)
            {
                if (entity.Id > 0)
                {
                    _dbSet.Attach(entity);
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    _dbSet.Add(entity);
                    _dbContext.SaveChanges();
                }
            }
        }
        public class Entity
        {
            public int Id { get; set; }
        }

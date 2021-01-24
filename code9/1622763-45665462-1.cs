    public class BaseRepository<T> : BaseRepositoryInterface<T> where T : class, EntityInterface {
      private readonly MyEntities _ctx;
      private readonly DbSet<T> _dbSet;
      private readonly ILog _logger;
  
      public BaseRepository(AkivaLiebermanEntities ctx, ILog logger) {
      _ctx = ctx;
      _dbSet = _ctx.Set<T>();
      _logger = logger;
    }
  
      public T GetByID(int id) {
      return _dbSet.FirstOrDefault(e => e.ID == id);
    }
  
      public IEnumerable<T> GetAll() {
      return _dbSet;
    }
  
      public T Update(T entity) {
        _logger.Debug("Update(" + entity.ID + ") - " + entity.Description);
        T existingEntity = GetByID(entity.ID);
        if (existingEntity == null) {
          return CreateNew(entity);
        }
        try {
          _ctx.Entry(existingEntity).CurrentValues.SetValues(entity);
          _ctx.SaveChanges();
        }
        catch (Exception ex) {
          _logger.Error("Exception: " + ex.MessageStack());
          throw;
        }
        return existingEntity;
      }
  
      private T CreateNew(T newEntity) {
        _logger.Debug("CreateNew()");
        try {
          _dbSet.Add(newEntity);
          _ctx.SaveChanges();
        }
        catch (Exception ex) {
          _logger.Error("Exception: " + ex.MessageStack());
          throw;
        }
        _logger.Debug("CreateNew() - new entity: " + newEntity.Description);
        return newEntity;
      }
  
      public virtual void Delete(int id) {
        T entity = _dbSet.FirstOrDefault(e => e.ID == id);
        if (entity != null) {
          _logger.Debug("Delete(" + id + ") - " + entity.Description);
          try {
            _dbSet.Remove(entity);
            _ctx.SaveChanges();
          }
          catch (Exception ex) {
            _logger.Error("Exception: " + ex.MessageStack());
            throw;
          }
        } else {
          _logger.Debug("Delete(" + id + ") - Not found");
        }
      }
    }

    public class BaseEntityApiController<TRepository, TEntity> : ApiController
        where TRepository : BaseRepository<TEntity>, new()
        where TEntity : BaseEntity, new()
    {
        // ...
    }

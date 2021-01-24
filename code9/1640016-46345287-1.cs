    public static class RepositoryExtensions
    {
        // similar to your MagicFunction
        public static TEntity GetById<TEntity>(this IRepository<TEntity> repository, int id)
             where TEntity : class, IEntity
        {
            return repository.Entities.Single(entity => entity.Id == id);
        }
    }

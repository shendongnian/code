    public interface IAsyncQueryablePostRequestHandler<TResponse>
    {
        Task Handle(ref TResponse response);
    }
    
    public class PostTenantQueryableFilterHandler<TResponse> : IAsyncQueryablePostRequestHandler<TResponse>
        where TResponse : IQueryable<IMultitenantEntity>
    {
        public Task Handle(ref TResponse response)
        {
            response = PostTenantQueryableFilter.Handle((dynamic)response);
            return Task.FromResult(1);
        }
    }
    static class PostTenantQueryableFilter
    {
        public static IQueryable<TEntity> Handle<TEntity>(IQueryable<TEntity> response)
            where TEntity : class, IMultitenantEntity
        {
            return response.Where(t => t.TenantId == 1);
        }
    }

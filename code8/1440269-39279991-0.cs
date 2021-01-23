    public interface IAsyncQueryablePostRequestHandler<TResponse>
    {
        Task Handle(ref TResponse response);
    }
    
    public class PostTenantQueryableFilterHandler<TResponse> : IAsyncQueryablePostRequestHandler<TResponse>
        where TResponse : IQueryable<IMultitenantEntity>
    {
        public Task Handle(ref TResponse response)
        {
            var parameter = Expression.Parameter(response.ElementType, "t");
            var predicate = Expression.Lambda(
    	        Expression.Equal(
                    Expression.Property(parameter, "TenantId"),
                    Expression.Constant(1)),
                parameter);
            var whereCall = Expression.Call(
                typeof(Queryable), "Where", new[] { parameter.Type },
                response.Expression, Expression.Quote(predicate));
            response = (TResponse)response.Provider.CreateQuery(whereCall);
            return Task.FromResult(1);
        }
    }

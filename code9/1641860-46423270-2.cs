	public interface IWrapper<TResult>
	{
		Task<TResult> ExecuteAsync(IQuery<TResult> query);
	}
	
    public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
    {
        var wrapperType =
            typeof(Wrapper<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var wrapper = (IWrapper<TResult>)_context.Resolve(wrapperType);
        return wrapper.ExecuteAsync(query);
    }
    // Don't forget to register this type by itself in Autofac.
	public class Wrapper<TQuery, TResult> : IWrapper<TResult>
	{
		private readonly IQueryHandler<TQuery, TResult> handler;
		public Wrapper(IQueryHandler<TQuery, TResult> handler) { this.handler = handler; }
		Task<TResult> IWrapper<TResult>.ExecuteAsync(IQuery<TResult> query) =>
			this.handler.ExecuteAsync((TQuery)query);
	}

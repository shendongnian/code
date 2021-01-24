    public class QueryBus
    {
        public object Resolve<THandler, TQuery, TResult>(TQuery query) 
            where T: IQueryHandler<TQuery, TResult>, IQueryHandler, new()
            where TResult : class 
            where TQuery: class
        {
            return new THandler().Execute(query);
        }
    }

    public class DataQueryHandlers<in TQuery, out TResult> : IQueryHandler<TQuery, TResult> where TResult : class where TQuery : IQuery<TResult>
    {
        private IDataSource source;
    
        public DataQueryHandlers(IDataSource source)
        {
            this.source = source
        }
    
        public TResult Handle(TQuery query)
        {
            // Get the data here and return TResult object
        }
    }

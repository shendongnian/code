    public class DataAccessHandler<T>
    {
        private Func<QueryResultItem, T> queryResultProcessingLogic;
    
        public DataAccessHandler(Func<QueryResultItem, T> queryResultProcessingLogic)
        {
            // Validation goes here
            this.queryResultProcessingLogic = queryResultProcessingLogic;
        }
    
        public List<T> Retrieve(string filter = null)
        {
            QueryResult queryResult = // Retrieve query results given query. this is your custom implementation. QueryResult type is an abstraction, you'll have to replace it with the actual type you use. I'm sharing just the concept here.
            return queryResult.Select(item=>queryResultProcessingLogic(item)).ToList();
        }
    }
    
    public class Controller1 : ApiController
    {
        private readonly DataAccessHandler<C1> dataHandler;
    
        public Controller1 ( DataAccessHandler<C1> dataHandler)
        {
            // Validate arguments here
    
            this.dataHandler = dataHandler;
        }
    
        public List<C1> GetAll(string filter)
        {
            return this.dataHandler.GetAll(filter);
        }
    }

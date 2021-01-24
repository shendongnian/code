    public interface IQueryExecutor
    {
        T ExecuteQuery<T>(IQuery<T> query);
    
        T ExecuteQuery<T, T1>(IQuery<T, T1> query, T1 input);        
    }

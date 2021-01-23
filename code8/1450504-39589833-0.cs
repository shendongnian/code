    public Task<ResultOrException<T>[]> WhenAllOrException<T>(IEnumerable<Task<T>> tasks)
    {    
        return Task.WhenAll(
            tasks.Select(
                task => task.ContinueWith(
                    t => t.IsFaulted
                        ? new ResultOrException<T>(t.Exception)
                        : new ResultOrException<T>(t.Result))));
    }
    
    
    public class ResultOrException<T>
    {
        public ResultOrException(T result)
        {
            IsSuccess = true;
            Result = result;
        }
        
        public ResultOrException(Exception ex)
        {
            IsSuccess = false;
            Exception = ex;
        }
    
        public bool IsSuccess { get; }
        public T Result { get; }
        public Exception Exception { get; }
    }

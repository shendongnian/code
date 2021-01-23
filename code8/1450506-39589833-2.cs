    public Task<ResultOrException<T>[]> WhenAllOrException<T>(IEnumerable<Task<T>> tasks)
    {    
        return Task.WhenAll(tasks.Select(task => WrapResultOrException(task)));
    }
    
    private async Task<ResultOrException<T>> WrapResultOrException<T>(Task<T> task)
    {
        try
        {	        
            var result = await task;
            return new ResultOrException<T>(result);
        }
        catch (Exception ex)
        {
            return new ResultOrException<T>(ex);
        }
    }

    /// Untested code
    static class Retry
    {
        public static async Task<T> Run<T>(Func<CancellationToken, Task<T>> function, int retries, TimeSpan timeout)
        {
            Exception error = null;
            while (retries > 0)
            {
                try
                {
                    var cancellation = new CancellationTokenSource(timeout);
                    return await function(cancellation.Token).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    error = ex;
                }
    
                retries--;
            }
    
            throw error;
        }
    
        public static async Task<T> Run<T>(Func<Task<T>> function, int retries, TimeSpan timeout)
        {
            Exception error = null;
            while (retries > 0)
            {
                try
                {
                    var timeoutTask = Task.Delay(timeout);
                    var resultTask = function();
    
                    await Task.WhenAny(resultTask, timeoutTask).ConfigureAwait(false);
    
                    if (resultTask.Status == TaskStatus.RanToCompletion)
                        return resultTask.Result;
                    else
                        error = new TimeoutException();
                }
                catch (Exception ex)
                {
                    error = ex;
                }
    
                retries--;
            }
    
            throw error;
        }
    }

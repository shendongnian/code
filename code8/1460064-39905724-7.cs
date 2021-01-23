    public static class Retry
    {
        // This method stays the same
        // Returning an IRetryCondition does not make sense in a "void" action
        public static void Do(
           Action action,
           TimeSpan retryInterval,
           int retryCount = 3)
        {
            Do<object>(() => 
            {
                action();
                return null;
            }, retryInterval, retryCount);
        }
        // Return an IRetryCondition<T> instance
        public static IRetryCondition<T> Do<T>(
           Func<T> action, 
           TimeSpan retryInterval,
           int retryCount = 3)
        {
            var exceptions = new List<Exception>();
            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                { 
                   if (retry > 0)
                      Thread.Sleep(retryInterval);
                   // We return a retry condition loaded with the return value of action() and telling it to execute this same method again if condition is not met.
                   return new RetryCondition<T>(action(), () => Do(action, retryInterval, retryCount));
                }
                catch (Exception ex)
                { 
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }
    }

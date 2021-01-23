    public static IRetryCondition<T> Do<T>(Func<T> action, 
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
               return new RetryCondition<T>(action(), () => Do(action, retryInterval, retryCount));
           }
           catch (Exception ex)
           { 
               exceptions.Add(ex);
           }
        }
        throw new AggregateException(exceptions);
    }

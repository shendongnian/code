    public static Task Do<T>(Func<T> action, TimeSpan retryInterval, Predicate<T> predicate)
            {
                var exceptions = new List<Exception>();
                try
                {
                    bool succeeded;
                    T result;
                    do
                    {
                        result = action();
                        succeeded = predicate(result);
                    } while (!succeeded);
    
                    return Task.FromResult(result);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
                throw new AggregateException(exceptions);
            }

    public class RetryWrapper
        {
            public static TOutput Execute<TInput, TOutput>(Func<TInput, TOutput> func, TInput input)
            {
                RetryPolicy retryPolicy = Policy.Handle<TimeoutException>()
                    .Or<OtherException>()
                    .WaitAndRetry(3, x => new TimeSpan(0, 0, 2));
    
                return retryPolicy.Execute(() => func(input));
            }
        }

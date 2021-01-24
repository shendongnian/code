    public class RetryWrapper
    {
        private const Int32 RetryTimes = 3;
        
        // Can be private if you don't need all available to caller.
        public IList<Exception> Exceptions { get; private set; }
        public Exception LastException => Exceptions.LastOrDefault() ?? null;
        public Boolean Failed => Exceptions.Count == _retryTimes;
        
        public RetryWrapper() {
            Exceptions = new List<Exception>();
        }
    
        public Task IncrementalAsync(Func<Task> action)
        {
            var retryStrategy = new Incremental(RetryTimes, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
    
            var retryPolicy = new RetryPolicy<AzureServiceBusDetectionStrategy>(retryStrategy);
            
            retryPolicy.Retrying += (sender, args) =>
            {
                Console.WriteLine("Retry - Count = {0}, Delay = {1}, Exception = {2}",
                args.CurrentRetryCount, args.Delay, args.LastException.Message);
                Exceptions.Add(args.LastException);
            };
    
            return retryPolicy.ExecuteAsync(action);
        }
    }

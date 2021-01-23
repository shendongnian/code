    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    
    namespace SomeNamespace
    {
        public class RequestLimiter : IRequestLimiter
        {
            private readonly ConcurrentQueue<DateTime> _requestTimes;
            private readonly TimeSpan _timeSpan;
    
            private readonly object _locker = new object();
    
            public RequestLimiter()
            {
                _timeSpan = TimeSpan.FromSeconds(1);
                _requestTimes = new ConcurrentQueue<DateTime>();
            }
    
            public TResult Run<TResult>(int requestsOnSecond, Func<TResult> function)
            {
                WaitUntilRequestCanBeMade(requestsOnSecond).Wait();
                return function();
            }
    
            private Task WaitUntilRequestCanBeMade(int requestsOnSecond)
            {
                return Task.Factory.StartNew(() =>
                {
                    while (!TryEnqueueRequest(requestsOnSecond).Result) ;
                });
            }
    
            private Task SynchronizeQueue()
            {
                return Task.Factory.StartNew(() =>
                {
                    _requestTimes.TryPeek(out var first);
    
                    while (_requestTimes.Count > 0 && (first.Add(_timeSpan) < DateTime.UtcNow))
                        _requestTimes.TryDequeue(out _);
                });
            }
    
            private Task<bool> TryEnqueueRequest(int requestsOnSecond)
            {
                lock (_locker)
                {
                    SynchronizeQueue().Wait();
                    if (_requestTimes.Count < requestsOnSecond)
                    {
                        _requestTimes.Enqueue(DateTime.UtcNow);
                        return Task.FromResult(true);
                    }
                    return Task.FromResult(false);
                }
            }
        }
    }

    public class ThrottledProducerConsumer<T>
    {
        private BufferBlock<T> _queue;
        private IPropagatorBlock<T, T> _throttleBlock;
        private List<Task> _consumers;
        private static IPropagatorBlock<T1, T1> CreateThrottleBlock<T1>(TimeSpan Interval, 
            Int32 MaxPerInterval, Int32 BlockBoundedMax = 2, Int32 BlockMaxDegreeOfParallelism = 2)
        {
            SemaphoreSlim _sem = new SemaphoreSlim(MaxPerInterval, MaxPerInterval);
            return new TransformBlock<T1, T1>(async (x) =>
            {
                //Log($"Transform blk: {x} {DateTime.UtcNow:mm:ss:ff} Semaphore Count: {_sem.CurrentCount}");
                var sw = new Stopwatch();
                sw.Start();
                //Console.WriteLine($"Current count: {_sem.CurrentCount}");
                await _sem.WaitAsync();
                sw.Stop();
                var delayTask = Task.Delay(Interval).ContinueWith((t) =>
                {
                    //Log($"Pre-RELEASE: {x} {DateTime.UtcNow:mm:ss:ff} Semaphore Count {_sem.CurrentCount}");
                    _sem.Release();
                    //Log($"PostRELEASE: {x} {DateTime.UtcNow:mm:ss:ff} Semaphoere Count {_sem.CurrentCount}");
                });
                //},TaskScheduler.FromCurrentSynchronizationContext());                
                //Log($"Transformed: {x} in queue {sw.ElapsedMilliseconds}ms. {DateTime.Now:mm:ss:ff} will release {DateTime.Now.Add(Interval):mm:ss:ff} Semaphoere Count {_sem.CurrentCount}");
                return x;
            },
                 //-- Might be better to keep Bounded Capacity in sync with the semaphore
                 new ExecutionDataflowBlockOptions { BoundedCapacity = BlockBoundedMax,
                     MaxDegreeOfParallelism = BlockMaxDegreeOfParallelism });
        }
        public ThrottledProducerConsumer(TimeSpan Interval, int MaxPerInterval, 
            Int32 QueueBoundedMax = 5, Action<T> ConsumerAction = null, Int32 MaxConsumers = 1, 
            Int32 MaxThrottleBuffer = 20, Int32 MaxDegreeOfParallelism = 10)
        {
            //-- Probably best to link MaxPerInterval and MaxThrottleBuffer 
            //  and MaxConsumers with MaxDegreeOfParallelism
            var consumerOptions = new ExecutionDataflowBlockOptions { BoundedCapacity = 1, };
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true,  };
            //-- Create the Queue
            _queue = new BufferBlock<T>(new DataflowBlockOptions { BoundedCapacity = QueueBoundedMax, });
            //-- Create and link the throttle block
            _throttleBlock = CreateThrottleBlock<T>(Interval, MaxPerInterval);
            _queue.LinkTo(_throttleBlock, linkOptions);
            //-- Create and link the consumer(s) to the throttle block
            var consumerAction = (ConsumerAction != null) ? ConsumerAction : new Action<T>(ConsumeItem);
            _consumers = new List<Task>();
            for (int i = 0; i < MaxConsumers; i++)
            {
                var consumer = new ActionBlock<T>(consumerAction, consumerOptions);
                _throttleBlock.LinkTo(consumer, linkOptions);
                _consumers.Add(consumer.Completion);
            }
            //-- TODO: Add some cancellation tokens to shut this thing down
        }
       /// <summary>
       /// Default Consumer Action, just prints to console
       /// </summary>
       /// <param name="ItemToConsume"></param>
        private void ConsumeItem(T ItemToConsume)
        {
            Log($"Consumed {ItemToConsume} at {DateTime.UtcNow}");
        }
        public async Task EnqueueAsync(T ItemToEnqueue)
        {
            await this._queue.SendAsync(ItemToEnqueue);
        }
        public async Task EnqueueItemsAsync(IEnumerable<T> ItemsToEnqueue)
        {
            foreach (var item in ItemsToEnqueue)
            {
                await this._queue.SendAsync(item);
            }
        }
        public async Task CompleteAsync()
        {
            this._queue.Complete();
            await Task.WhenAll(_consumers);
            Console.WriteLine($"All consumers completed {DateTime.UtcNow}");
        }
        private static void Log(String messageToLog)
        {
            System.Diagnostics.Trace.WriteLine(messageToLog);
            Console.WriteLine(messageToLog);
        }
    }

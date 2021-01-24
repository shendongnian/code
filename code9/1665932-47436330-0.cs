    using System;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace MyApp.Services
    {
        /// <summary>
        /// This service is meant to allow for scheduling memory intensive tasks,
        /// a maximum number of these types of tasks is defined, scheduling via
        /// this service guarantees no more than the max number of tasks are executed
        /// at once.
        /// </summary>
        public class MemoryIntensiveTaskService
        {
            private class ExecutionObject
            {
                public Func<object> Task { get; set; }
                public AutoResetEvent Event { get; set; }
                public object Result { get; set; }
    
                public T CastResult<T>()
                {
                    return (T)Result;
                }
            }
    
            private static readonly int MaxConcurrency = 2;
    
            private static BlockingCollection<ExecutionObject> _queue = new BlockingCollection<ExecutionObject>();
    
            static MemoryIntensiveTaskService()
            {
                // Load MaxConcurrency number of consumers
                for (int i = 0; i < MaxConcurrency; i++)
                    Task.Factory.StartNew(Consumer);
            }
    
            public T ScheduleTaskAndWait<T>(Func<T> action)
            {
                var executionObject = new ExecutionObject
                {
                    Task = () => action(),
                    Event = new AutoResetEvent(false),
                    Result = null
                };
    
                // Add item to queue, will be picked up ASAP by a
                // consumer
                _queue.Add(executionObject);
    
                // Wait for completion
                executionObject.Event.WaitOne();
    
                return executionObject.CastResult<T>();
            }
    
            private static void Consumer()
            {
                while (true)
                {
                    var executionObject = _queue.Take();
    
                    // Execute task, store result
                    executionObject.Result = executionObject.Task();
    
                    // Fire event to signal to producer that execution
                    // has finished
                    executionObject.Event.Set();
                }
            }
        }
    }

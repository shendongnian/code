csharp
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace parallel
{
    class Program
    {
        private static Random Rand = new Random();
        static void Main(string[] args)
        {
            var ts = new LimitedConcurrencyLevelTaskScheduler(10);
            var taskFactory = new TaskFactory(ts);
            while (true)
            {
                var context = GetContext(ts);
                if (context.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;
                taskFactory.StartNew(() => HandleContextAsync(context));
            }
            Console.WriteLine("Waiting...");
            while (ts.CountRunning != 0)
            {
                Console.WriteLine("Now running {0}x tasks with {1}x queued.", ts.CountRunning, ts.CountQueued);
                Thread.Yield();
                Thread.Sleep(100);
            }
        }
        private static void HandleContextAsync(string context)
        {
            // delays for 1-10 seconds to make the example easier to understand
            Thread.Sleep(Rand.Next(1000, 10000));
            Console.WriteLine("Context: {0}, from thread: {1}", context, Thread.CurrentThread.ManagedThreadId);
        }
        private static string GetContext(LimitedConcurrencyLevelTaskScheduler ts)
        {
            Console.WriteLine("Now running {0}x tasks with {1}x queued.", ts.CountRunning, ts.CountQueued);
            return Console.ReadLine();
        }
    }
    // Provides a task scheduler that ensures a maximum concurrency level while 
    // running on top of the thread pool.
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;
        // The list of tasks to be executed 
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)
        public int CountRunning => _nowRunning;
        public int CountQueued
        {
            get
            {
                lock (_tasks)
                {
                    return _tasks.Count;
                }
            }
        }
        // The maximum concurrency level allowed by this scheduler. 
        private readonly int _maxDegreeOfParallelism;
        // Indicates whether the scheduler is currently processing work items. 
        private volatile int _delegatesQueuedOrRunning = 0;
        private volatile int _nowRunning;
        // Creates a new instance with the specified degree of parallelism. 
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1)
                throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
        }
        // Queues a task to the scheduler. 
        protected sealed override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough 
            // delegates currently queued or running to process tasks, schedule another. 
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    Interlocked.Increment(ref _delegatesQueuedOrRunning);
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }
        // Inform the ThreadPool that there's work to be executed for this scheduler. 
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items.
                // This is necessary to enable inlining of tasks into this thread.
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue.
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            // When there are no more items to be processed,
                            // note that we're done processing, and get out.
                            if (_tasks.Count == 0)
                            {
                                Interlocked.Decrement(ref _delegatesQueuedOrRunning);
                                break;
                            }
                            // Get the next item from the queue
                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }
                        // Execute the task we pulled out of the queue
                        Interlocked.Increment(ref _nowRunning);
                        if (base.TryExecuteTask(item))
                            Interlocked.Decrement(ref _nowRunning);
                    }
                }
                // We're done processing items on the current thread
                finally { _currentThreadIsProcessingItems = false; }
            }, null);
        }
        // Attempts to execute the specified task on the current thread. 
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining
            if (!_currentThreadIsProcessingItems) return false;
            // If the task was previously queued, remove it from the queue
            if (taskWasPreviouslyQueued)
                // Try to run the task. 
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }
        // Attempt to remove a previously scheduled task from the scheduler. 
        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }
        // Gets the maximum concurrency level supported by this scheduler. 
        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }
        // Gets an enumerable of the tasks currently scheduled on this scheduler. 
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }
    }
}

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main (string[] args)
            {
                var buffer = CreateBuffer (); 
                var executor = new Executor<string> (SomeWork, buffer);
                executor.ProcessingStarted += Executor_ProcessingStarted;
                string userInput = null;
                do
                {
                    userInput = Console.ReadLine ();
                    buffer.Enqueue (userInput);
                }
                while (!string.IsNullOrWhiteSpace (userInput));
                executor.Dispose ();
            }
            //----------------------------------------------------------------------------------------------------------------------------------
            private static IBuffer<string> CreateBuffer ()
            {
                var buffer = new UniqueItemsBuffer<string> (3);
                buffer.DataAvailable += (items) => Console.WriteLine ("BUFFER :: data available raised.");
                var alert = new Alert ();
                var bufferWithTimeout = new BufferWithTimeout<string> (buffer, alert, TimeSpan.FromSeconds (5));
                return bufferWithTimeout;
            }
            //----------------------------------------------------------------------------------------------------------------------------------
            static Random rnd = new Random (); // must be outside, to avoid creating Random too quick because it will use the same seed for all tasks
            public static bool SomeWork (string x)
            {
                int delay = rnd.Next (1000, 8000);
                Console.WriteLine ($"  +++ Starting SomeWork for: {x}, delay: {delay} ms");
                Thread.Sleep (delay);
                Console.WriteLine ($"  --- SomeWork for: {x} - finished.");
                return true;
            }
            //----------------------------------------------------------------------------------------------------------------------------------
            private static void Executor_ProcessingStarted (IReadOnlyList<Task<bool>> items)
            {
                Task.Run (() =>
                {
                    Task.WaitAll (items.ToArray ());
                    Console.WriteLine ("Finished processing tasks, count = " + items.Count);
                });
            }
        }
        //====== actual code ===================================================================================================================
        public delegate void ItemsAvailable<T> (IReadOnlyList<T> items); // new type to simplify code
        public delegate bool ProcessItem<T> (T item); // processes the given item and returns true if job is done with success
        //======================================================================================================================================
        public interface IDataAvailableEvent<T>
        {
            event ItemsAvailable<T> DataAvailable; // occurs when buffer need to be processed (also before raising this event, buffer should be cleared)
        }
        //======================================================================================================================================
        public interface IProcessingStartedEvent<T>
        {
            event ItemsAvailable<Task<bool>> ProcessingStarted; // executor raises this event when all tasks are created and started
        }
        //======================================================================================================================================
        public interface IBuffer<T> : IDataAvailableEvent<T>
        {
            bool Enqueue (T item); // adds new item to buffer (but sometimes it can ignore item, for example if we need only unique items in list)
                                   // returns: true = buffer is not empty, false = is emtpy
            void FlushBuffer ();   // should clear buffer and raise event (or not raise if buffer was already empty)
        }
        //======================================================================================================================================
        // raises DataAvailable event when buffer cap is reached
        // ignores duplicates
        // you can only use this class from one thread
        public class UniqueItemsBuffer<T> : IBuffer<T>
        {
            public event ItemsAvailable<T> DataAvailable;
            readonly int capacity;
            HashSet<T> items = new HashSet<T> ();
            public UniqueItemsBuffer (int capacity = 10)
            {
                this.capacity = capacity;
            }
            public bool Enqueue (T item)
            {
                if (items.Add (item) && items.Count == capacity)
                {
                    FlushBuffer ();
                }
                return items.Count > 0;
            }
            public void FlushBuffer ()
            {
                Console.WriteLine ("BUFFER :: flush, item count = " + items.Count);
                if (items.Count > 0)
                {
                    var itemsCopy = items.ToList ();
                    items.Clear ();
                    DataAvailable?.Invoke (itemsCopy);
                }
            }
        }
        //======================================================================================================================================
        public class Executor<T> : IProcessingStartedEvent<T>, IDisposable
        {
            public event ItemsAvailable<Task<bool>> ProcessingStarted;
            readonly ProcessItem<T> work;
            readonly IDataAvailableEvent<T> dataEvent;
            public Executor (ProcessItem<T> work, IDataAvailableEvent<T> dataEvent)
            {
                this.work = work;
                this.dataEvent = dataEvent;
                dataEvent.DataAvailable += DataEvent_DataAvailable;
            }
            private void DataEvent_DataAvailable (IReadOnlyList<T> items)
            {
                Console.WriteLine ("EXECUTOR :: new items to process available, count = " + items.Count);
                var list = new List<Task<bool>> ();
                foreach (var item in items)
                {
                    var task = Task.Run (() => work (item));
                    list.Add (task);
                }
                Console.WriteLine ("EXECUTOR :: raising processing started event (this msg can appear later than messages from SomeWork)");
                ProcessingStarted?.Invoke (list);
            }
            public void Dispose ()
            {
                dataEvent.DataAvailable -= DataEvent_DataAvailable;
            }
        }
        //======================================================================================================================================
        // if you want to fill buffer using many threads - use this decorator
        public sealed class ThreadSafeBuffer<T> : IBuffer<T>
        {
            public event ItemsAvailable<T> DataAvailable;
            readonly IBuffer<T> target;
            readonly object sync = new object ();
            private ThreadSafeBuffer (IBuffer<T> target)
            {
                this.target = target;
                this.target.DataAvailable += (items) => DataAvailable?.Invoke (items); // TODO: unpin event :P
            }
            public bool Enqueue (T item)
            {
                lock (sync) return target.Enqueue (item);
            }
            public void FlushBuffer ()
            {
                lock (sync) target.FlushBuffer ();
            }
            public static IBuffer<T> MakeThreadSafe (IBuffer<T> target)
            {
                if (target is ThreadSafeBuffer<T>) return target;
                return new ThreadSafeBuffer<T> (target);
            }
        }
        //======================================================================================================================================
        // and now if you want to process buffer after elapsed time
        public interface IAlert
        {
            CancellationTokenSource CreateAlert (TimeSpan delay, Action action); // will execute 'action' after given delay (non blocking)
        }
        // I didn't use much timers, so idk is this code good
        public class Alert : IAlert
        {
            List<System.Timers.Timer> timers = new List<System.Timers.Timer> (); // we need to keep reference to timer to avoid dispose
            public CancellationTokenSource CreateAlert (TimeSpan delay, Action action)
            {
                var cts = new CancellationTokenSource ();
                var timer = new System.Timers.Timer (delay.TotalMilliseconds);
                timers.Add (timer);
                timer.Elapsed += (sender, e) =>
                {
                    timers.Remove (timer);
                    timer.Dispose ();
                    if (cts.Token.IsCancellationRequested) return;
                    action.Invoke ();
                };
                timer.AutoReset = false; // just one tick
                timer.Enabled = true;
                return cts;
            }
        }
        // thread safe (maybe :-D)
        public class BufferWithTimeout<T> : IBuffer<T>
        {
            public event ItemsAvailable<T> DataAvailable;
            readonly IBuffer<T> target;
            readonly IAlert     alert;
            readonly TimeSpan   timeout;
            CancellationTokenSource cts;
            readonly object sync = new object ();
            public BufferWithTimeout (IBuffer<T> target, IAlert alert, TimeSpan timeout)
            {
                this.target  = ThreadSafeBuffer<T>.MakeThreadSafe (target); // alert can be raised from different thread
                this.alert   = alert;
                this.timeout = timeout;
                target.DataAvailable += Target_DataAvailable; // TODO: unpin event
            }
            private void Target_DataAvailable (IReadOnlyList<T> items)
            {
                lock (sync)
                {
                    DisableTimer ();
                }
                DataAvailable?.Invoke (items);
            }
            public bool Enqueue (T item)
            {
                lock (sync)
                {
                    bool hasItems = target.Enqueue (item); // can raise underlying flush -> dataAvailable event (will disable timer)
                    // and now if buffer is empty, we cannot start timer
                    if (hasItems && cts == null) // if timer is not enabled
                    {
                        Console.WriteLine ("TIMER :: created alert");
                        cts = alert.CreateAlert (timeout, HandleAlert);
                    }
                    return hasItems;
                }
            }
            public void FlushBuffer ()
            {
                lock (sync)
                {
                    DisableTimer ();
                    target.FlushBuffer ();
                }
            }
            private void HandleAlert ()
            {
                lock (sync)
                {
                    Console.WriteLine ("TIMER :: handler, will call buffer flush");
                    target.FlushBuffer ();
                }
            }
            private void DisableTimer ()
            {
                cts?.Cancel ();
                cts = null;
                Console.WriteLine ("TIMER :: disable");
            }
        }
    }

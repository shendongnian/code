    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                // checks that WaitAll doesn't reset event
                var ev1 = new AutoResetEvent(true);
                var ev2 = new AutoResetEvent(false);
                WaitHandle.WaitAll(new [] { ev1, ev2}, 1000);
                ev1.WaitOne();
                int counter = 0;
                var m = new MyMonitor();
                var m2 = new MyMonitor();
                var tasks = Enumerable.Range(0, 1000).Select(
                    x => Task.Run(
                        () =>
                        {
                            for (int i = 1; i <= 1000; i++)
                            {
                                if (!MyMonitor.TryAcquireMany(100000, m, m2)) throw new TimeoutException();
                                counter++;
                                m.Release();
                                m2.Release();
                            }
                        })).ToArray();
                Task.WaitAll(tasks);
                Console.WriteLine(counter + " should be " + (1000 * 1000));
                Console.ReadLine();
            }
        }
    
        class MyMonitor
        {
            readonly AutoResetEvent _event = new AutoResetEvent(true);
    
            public static bool TryAcquireMany(int timeout, params MyMonitor[] monitors)
            {
                return WaitHandle.WaitAll(monitors.Select(x => (WaitHandle)x._event).ToArray(), timeout);
            }
    
            public bool TryAcquire(int timeout)
            {
                return _event.WaitOne(timeout);
            }
    
            public void Release()
            {
                _event.Set();
            }
        }
    }

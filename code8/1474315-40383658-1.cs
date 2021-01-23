    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            const int TASK_COUNT = 3;
            static readonly Barrier barrier = new Barrier(TASK_COUNT);
            static readonly AutoResetEvent gate = new AutoResetEvent(true);
            static void Main()
            {
                Parallel.Invoke(task, task, task);
            }
            static void task()
            {
                while (true)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " is waiting at the gate.");
                    // This bool is just for test purposes to prevent the same thread from doing the
                    // work every time!
                    bool didWork = false; 
                    if (gate.WaitOne(0))
                    {
                        work();
                        didWork = true;
                        gate.Set();
                    }
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " is waiting at the barrier.");
                    barrier.SignalAndWait();
                    if (didWork)
                        Thread.Sleep(10); // Give a different thread a chance to get past the gate!
                }
            }
            static void work()
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " is entering work()");
                Thread.Sleep(3000);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " is leaving work()");
            }
        }
    }
    

    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    
    namespace TestSO42101517WaitAsyncTasks
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
                int maxTasks = 30,
                    maxActive = 3,
                    maxDelayMs = 1000,
                    currentDelay = -1;
                ConcurrentQueue<TimeSpan> taskDelays = new ConcurrentQueue<TimeSpan>();
    
                for (int i = 0; i < maxTasks; i++)
                {
                    taskDelays.Enqueue(TimeSpan.FromMilliseconds(random.Next(maxDelayMs)));
                }
    
                Task[] tasks = new Task[maxActive];
    
                for (int i = 0; i < maxActive; i++)
                {
                    int workerIndex = i;
    
                    tasks[i] = Task.Run(() =>
                    {
                        DelayConsumer(ref currentDelay, taskDelays, workerIndex);
                    });
                }
    
                Console.WriteLine("Waiting for consumer tasks");
    
                Task.WaitAll(tasks);
    
                Console.WriteLine("All consumer tasks completed");
            }
    
            private static void DelayConsumer(ref int currentDelayIndex, ConcurrentQueue<TimeSpan> taskDelays, int workerIndex)
            {
                Console.WriteLine($"worker #{workerIndex} starting");
    
                while (true)
                {
                    TimeSpan delay;
    
                    if (!taskDelays.TryDequeue(out delay))
                    {
                        Console.WriteLine($"worker #{workerIndex} exiting");
                        return;
                    }
    
                    int delayIndex = System.Threading.Interlocked.Increment(ref currentDelayIndex);
    
                    Console.WriteLine($"worker #{workerIndex} sleeping for {delay.TotalMilliseconds} ms, task #{delayIndex}");
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
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
                List<TimeSpan> taskDelays = new List<TimeSpan>(maxTasks);
    
                for (int i = 0; i < maxTasks; i++)
                {
                    taskDelays.Add(TimeSpan.FromMilliseconds(random.Next(maxDelayMs)));
                }
    
                Task[] tasks = new Task[maxActive];
                object o = new object();
    
                for (int i = 0; i < maxActive; i++)
                {
                    int workerIndex = i;
    
                    tasks[i] = Task.Run(() =>
                    {
                        DelayConsumer(ref currentDelay, taskDelays, o, workerIndex);
                    });
                }
    
                Console.WriteLine("Waiting for consumer tasks");
    
                Task.WaitAll(tasks);
    
                Console.WriteLine("All consumer tasks completed");
            }
    
            private static void DelayConsumer(ref int currentDelay, List<TimeSpan> taskDelays, object o, int workerIndex)
            {
                Console.WriteLine($"worker #{workerIndex} starting");
    
                while (true)
                {
                    TimeSpan delay;    
                    int delayIndex;
    
                    lock (o)
                    {
                        delayIndex = ++currentDelay;
                        if (delayIndex < taskDelays.Count)
                        {
                            delay = taskDelays[delayIndex];
                        }
                        else
                        {
                            Console.WriteLine($"worker #{workerIndex} exiting");
                            return;
                        }
                    }
    
                    Console.WriteLine($"worker #{workerIndex} sleeping for {delay.TotalMilliseconds} ms, task #{delayIndex}");
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }
    }

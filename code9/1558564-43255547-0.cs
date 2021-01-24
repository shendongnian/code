    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp3
    {
        class Program
        {
            static Stopwatch sw = Stopwatch.StartNew();
            static void Main()
            {
                runTasks();
                setMinThreadPoolThreads(30);
                runTasks();
            }
            static void setMinThreadPoolThreads(int count)
            {
                Console.WriteLine("\nSetting min thread pool threads to {0}.\n", count);
                int workerThreads, completionPortThreads;
                ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
                ThreadPool.SetMinThreads(count, completionPortThreads);
            }
            static void runTasks()
            {
                var sw = Stopwatch.StartNew();
                Console.WriteLine("\nStarting tasks.");
                var task = test(20);
                Console.WriteLine("Waiting for tasks to finish.");
                task.Wait();
                Console.WriteLine("Finished after " + sw.Elapsed);
            }
            static async Task test(int n)
            {
                var tasks = new List<Task>();
                for (int i = 0; i < n; ++i)
                    tasks.Add(Task.Run(new Action(task)));
                await Task.WhenAll(tasks);
            }
            static void task()
            {
                Console.WriteLine("Task starting at time " + sw.Elapsed);
                Thread.Sleep(5000);
                Console.WriteLine("Task stopping at time " + sw.Elapsed);
            }
        }
    }

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace ConsoleApp1
    {
        public class Program
        {
            static void Main()
            {
                var inQueue  = new TransformBlock<int, int>(item => process(item), processBlockOptions());
                var outQueue = new ActionBlock<int>(item => output(item), outputBlockOptions());
                inQueue.LinkTo(outQueue, new DataflowLinkOptions {PropagateCompletion = true});
                var task = queueData(inQueue);
                Console.WriteLine("Waiting for task to complete in thread " + Thread.CurrentThread.ManagedThreadId);
                task.Wait();
                Console.WriteLine("Completed.");
            }
            static async Task queueData(TransformBlock<int, int> executor)
            {
                await enqueue(executor);
                Console.WriteLine("Indicating that no more data will be queued.");
                executor.Complete(); // Indicate that no more items will be queued.
                Console.WriteLine("Waiting for queue to empty.");
                await executor.Completion; // Wait for executor queue to empty.
            }
            static async Task enqueue(TransformBlock<int, int> executor)
            {
                for (int i = 0; i < 100; ++i)
                {
                    Console.WriteLine("Queuing data " + i);
                    int v = i;
                    await executor.SendAsync(v); // Queues a method that returns v.
                }
            }
            static int process(int value)  // Procss value by adding 1000 to it.
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is processing item {value}");
                value += 1000;
                Thread.Sleep(150+nextRand());  // Simulate work.
                Console.WriteLine($"Returning {value} from thread {Thread.CurrentThread.ManagedThreadId}");
                return value;
            }
            static void output(int value)
            {
                Console.WriteLine($"Outputting {value}");
            }
            static ExecutionDataflowBlockOptions processBlockOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 4,
                    BoundedCapacity = 8
                };
            }
            static ExecutionDataflowBlockOptions outputBlockOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 1,
                    BoundedCapacity = 1
                };
            }
            static int nextRand()
            {
                lock (rngLock)
                {
                    return rng.Next(250);
                }
            }
            static Random rng = new Random();
            static object rngLock = new object();
        }
    }
                           

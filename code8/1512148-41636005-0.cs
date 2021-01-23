    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace Demo
    {
        class Program
        {
            public static void Main()
            {
                var data = Enumerable.Range(1, 100);
                var task = Process(data);
                Console.WriteLine("Waiting for task to complete");
                task.Wait();
                Console.WriteLine("Task complete.");
            }
            public static async Task Process(IEnumerable<int> data)
            {
                var queue = new TransformBlock<int, int>(block => process(block), transformBlockOptions());
                var writer = new ActionBlock<int>(block => write(block), actionBlockOptions());
                queue.LinkTo(writer, new DataflowLinkOptions { PropagateCompletion = true });
                await enqueDataToProcessAndAwaitCompletion(data, queue);
                await writer.Completion;
            }
            static int process(int block)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is processing block {block}");
                emulateWorkload();
                return -block;
            }
            static void write(int block)
            {
                Console.WriteLine("Output: " + block);
            }
            static async Task enqueDataToProcessAndAwaitCompletion(IEnumerable<int> data, TransformBlock<int, int> queue)
            {
                await enqueueDataToProcess(data, queue);
                queue.Complete();
            }
            static async Task enqueueDataToProcess(IEnumerable<int> data, ITargetBlock<int> queue)
            {
                foreach (var item in data)
                    await queue.SendAsync(item);
            }
            static ExecutionDataflowBlockOptions transformBlockOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 8,
                    BoundedCapacity = 32
                };
            }
            private static ExecutionDataflowBlockOptions actionBlockOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 1,
                    BoundedCapacity = 1
                };
            }
            static Random rng = new Random();
            static object locker = new object();
            static void emulateWorkload()
            {
                int delay;
                lock (locker)
                {
                    delay = rng.Next(250, 750);
                }
                Thread.Sleep(delay);
            }
        }
    }

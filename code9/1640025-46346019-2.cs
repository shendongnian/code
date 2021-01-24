    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace Test
    {
        public class TestQueue
        {
            BlockingCollection<Job> _queue = new BlockingCollection<Job>();
            private static HttpClient _client = new HttpClient();
    
            public TestQueue()
            {
                WorkProducerThread();
                WorkConsumerThread();
            }
    
            public void WorkConsumerThread()
            {
                if (!_queue.IsCompleted)
                {
                    //At this point, 4 partitions are created but all records are in 1st partition only; 2,3,4 partition are empty
                    var partitioner = _queue.GetConsumingPartitioner().GetPartitions(4);
    
                    Task t = Task.WhenAll(
                     from partition in partitioner
                     select Task.Run(async () =>
                     {
                         using (partition)
                         {
                             while (partition.MoveNext())
                                 await CreateJobs(partition.Current);
                         }
                     }));
    
    
                    t.Wait();
    
                    Console.WriteLine(_queue.Count);
                }
            }
    
            private async Task CreateJobs(Job job)
            {
                //HttpContent bodyContent = null;
                //await _client.PostAsync("job", bodyContent);
                await Task.Delay(100);
            }
    
    
    
            public void WorkProducerThread()
            {
                if (_queue.Count == 0)
                {
                    try
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Job job = new Job { Id = i, JobName = "j" + i.ToString(), JobCreated = DateTime.Now };
                            _queue.TryAdd(job);
                        }
    
                        _queue.CompleteAdding();
                    }
                    catch (Exception ex)
                    {
                        //_Log.Error("Exception while adding jobs to collection", ex);
                    }
                }
            }
    
        }
    
        public class Job
        {
            public int Id { get; set; }
            public string JobName { get; set; }
            public DateTime JobCreated { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var g = new TestQueue();
    
                Console.ReadLine();
            }
        }
    }

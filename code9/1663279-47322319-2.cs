    class Program {
        static readonly BlockingCollection<ItemToProcess> _queue = new BlockingCollection<ItemToProcess>(new ConcurrentQueue<ItemToProcess>());
        static readonly CancellationTokenSource _cts = new CancellationTokenSource();
        static void Main(string[] args) {
            // get all unprocessed items from database here and insert into queue
            var producerThread = StartProducer(_cts.Token);
            var consumerThread = StartConsumer();
            Console.ReadKey();
            // cancel
            _cts.Cancel();
            // wait for producer thread to finish
            producerThread.Join();
            // notify there will be no more items
            _queue.CompleteAdding();
            // wait for consumer to finish
            consumerThread.Join();
        }
        static Thread StartProducer(CancellationToken ct) {
            var thread = new Thread(() => {
                while (!ct.IsCancellationRequested) {                    
                    // also insert into database here
                    _queue.Add(new ItemToProcess() {
                        Value = "value"
                    });
                    // imitate delay
                    Thread.Sleep(5000);
                }
            }) {
                IsBackground = true
            };
            thread.Start();
            return thread;
        }
        static Thread StartConsumer() {
            var thread = new Thread(() => {
                foreach (var item in _queue.GetConsumingEnumerable()) {
                    try {
                        // process
                        Console.WriteLine(item.Value);
                        // delete from database here
                    }
                    catch (Exception ex) {
                        // handle
                    }
                }
            }) {
                IsBackground = true
            };
            thread.Start();
            return thread;
        }
    }
    class ItemToProcess
    {
        public string Value { get; set; }
    }

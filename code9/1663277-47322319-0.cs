    class Program {        
        static readonly BlockingCollection<ItemToProcess> _queue = new BlockingCollection<ItemToProcess>(new ConcurrentQueue<ItemToProcess>());
        static void Main(string[] args)
        {
            // get all unprocessed items from database here and insert into queue
            StartProducer();
            StartConsumer();
            Console.ReadKey();
        }
        static void StartProducer() {
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    // also insert into database here
                    _queue.Add(new ItemToProcess()
                    {
                        Value = "value"
                    });
                }
            })
            {
                IsBackground = true
            }.Start();
        }
        static void StartConsumer() {
            new Thread(() =>
            {
                foreach (var item in _queue.GetConsumingEnumerable()) {
                    try {
                        // process
                        // delete from database here
                    }
                    catch (Exception ex) {
                        // handle
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }
        
    }
    class ItemToProcess {
        public string Value { get; set; }
    }

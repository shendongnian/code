    class CDataProducer
    {
        private readonly BlockingCollection<double> _queue = new BlockingCollection<double>();
        private double _value;
        public bool IsDone { get; private set; }
        public void Done()
        {
            IsDone = true;
            _queue.CompleteAdding();
        }
        public void ProduceNewData()
        {
            _queue.Add(++_value);
        }
        public void Consumer()
        {
            foreach (double value in _queue.GetConsumingEnumerable())
            {
                Console.WriteLine(Thread.CurrentThread.Name + ":" + value);
            }
        }
    }
    public static void startTest()
    {
        CDataProducer dataProducer = new CDataProducer();
        for (int i = 0; i < 5; i++)
        {
            Thread th = new Thread(dataProducer.Consumer);
            th.Name = "Thread" + (i + 1).ToString();
            th.Start();
        }
        Func<Task> waitAndDone = async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            dataProducer.Done();
        };
        Task waitAndDoneTask = waitAndDone();
        for (int i = 0; i < 7 && !dataProducer.IsDone; i++)
        {
            dataProducer.ProduceNewData();
            Thread.Sleep(1000);
        }
        waitAndDoneTask.Wait();
    }
    static void Main(string[] args)
    {
        startTest();
    }

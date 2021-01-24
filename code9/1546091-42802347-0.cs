    class CDataProducer
    {
        private readonly object _writeMonitor = new object();
        private readonly object _readMonitor = new object();
        private readonly object _lock = new object();
        private double _data;
        public bool IsDone { get; private set; }
        public void ProduceNewData()
        {
            lock (_writeMonitor)
            {
                if (!IsDone)
                {
                    lock (_lock)
                    {
                        _data++;
                    }
                    lock (_readMonitor) Monitor.PulseAll(_readMonitor);
                    Monitor.Wait(_writeMonitor);
                }
            }
        }
        public bool WaitData(out double result)
        {
            lock (_readMonitor)
            {
                Monitor.Wait(_readMonitor);
                lock (_lock)
                {
                    result = _data;
                }
                lock (_writeMonitor) Monitor.Pulse(_writeMonitor);
            }
            return true;
        }
        public void Done()
        {
            lock (_writeMonitor)
            {
                IsDone = true;
                Monitor.Pulse(_writeMonitor);
            }
        }
    }
    public static void startTest()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread th = new Thread(userThead);
            th.Name = "Thread" + (i + 1).ToString();
            th.IsBackground = true;
            th.Start();
        }
        Func<Task> waitAndDone = async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            m_DataProducer.Done();
        };
        Task waitAndDoneTask = waitAndDone();
        for (int i = 0; i < 7 && !m_DataProducer.IsDone; i++)
        {
            m_DataProducer.ProduceNewData();
            Thread.Sleep(1000);
        }
        waitAndDoneTask.Wait();
    }

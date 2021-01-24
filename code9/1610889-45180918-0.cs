    class MyBot
    {
        public MyBot()
        {
        }
        CancellationTokenSource cts;
        public void Start()
        {
            cts = new CancellationTokenSource();
            Task t = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    Console.WriteLine("RAID RAID");
                    Task.Delay(5000).Wait();
                }
            }, cts.Token);
        }
        public void Stop()
        {
            cts?.Cancel();
        }
    }

         public async Task Main_Solution()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Observable
                .Timer(TimeSpan.FromSeconds(4))
                .Subscribe(x =>
                {
                    Console.WriteLine("Cancel startedthread='{0}'", Thread.CurrentThread.ManagedThreadId);
                    cancellationTokenSource.Cancel();
                });
            await AwaitEverythingInARxChain(cancellationTokenSource.Token);
            Console.WriteLine("Cancel finished thread='{0}'", Thread.CurrentThread.ManagedThreadId);
            ShutDownDatabase();
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
        public async Task AwaitEverythingInARxChain(CancellationToken token)
        {
            IObservable<int> eventSource = Observable.Range(0, 10);
            await eventSource
                .ObserveOn(Scheduler.Default)
                .Select(id => LoadFromDatabase(id))
                .TakeWhile(_ => !token.IsCancellationRequested)
                .ObserveOn(Scheduler.Default) // Dispatcher in real life
                .Do(loadedData => UpdateUi(loadedData)).LastOrDefaultAsync();
        }
        public int LoadFromDatabase(int x)
        {
            Console.WriteLine("Start LoadFromDatabase: {0} thread='{1}'", x, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine("Finished LoadFromDatabase: {0} thread='{1}'", x, Thread.CurrentThread.ManagedThreadId);
            return x;
        }
        public void UpdateUi(int x)
        {
            Console.WriteLine("UpdateUi: '{0}' thread='{1}'", x, Thread.CurrentThread.ManagedThreadId);
        }
        public void ShutDownDatabase()
        {
            Console.WriteLine("ShutDownDatabase thread='{0}'", Thread.CurrentThread.ManagedThreadId);
        }

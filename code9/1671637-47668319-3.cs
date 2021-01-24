    class Cancel
    {
        CancellationTokenSource _source;
        public Cancel (CancellationTokenSource source)
        {
           _source = source;
        }
        public void cancelTask()
        {            
            _source.Cancel();
        }
    }
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            callasyncmethod(token);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Cancel c = new Cancel(source); // pass in the original source
            c.cancelTask();
            Console.ReadLine();
        }

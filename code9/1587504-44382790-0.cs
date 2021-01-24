    public static class ManualResetEventObservable
    {
        public static IObservable<bool> Create(ManualResetEvent e, TimeSpan timeout)
        {
            return Observable.Create<bool>(observer =>
            {
                bool doWait = true;
                var thread = new Thread(new ThreadStart(() =>
                {
                    while(doWait)
                    {
                        e.WaitOne(timeout);
                    }
                }));
                return Disposable.Create(() => { doWait = false; });
            });
        }
    }

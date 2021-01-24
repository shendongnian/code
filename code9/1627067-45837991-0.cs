        Func<Data> getData = () =>
        {
            //...
        };
        AsyncCallback callback = (IAsyncResult ar) =>
        {
            // do your thing...
            getData.EndInvoke(ar);
            waiter.Set();
        };
        
        ManualResetEvent waiter;
        
        void DoWork()
        {
            waiter = new ManualResetEvent(false);
            IAsyncResult result = getData.BeginInvoke(callback, null);
            waiter.WaitOne();
            //Callback has finished
        }

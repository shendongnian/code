    public Task CreateAndAwaitAsync()
    {
        T1 = new Task(() => {
            // time consuming work like:
            System.Threading.Thread.Sleep(1000);
        }
        // if you need to start it somewhere, do T1.Start();
        return T1;
    }

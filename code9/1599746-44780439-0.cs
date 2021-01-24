    static ManualResetEventSlim guard = new ManualResetEventSlim(true);
    private void button1_Click_1(object sender, EventArgs e)
    {
        guard.Reset();
        Reconnect();
        guard.Set();
    }
    private void RemoveItems()
    {
        string item;
        while (concurrentQueue.TryDequeue(out item))
        {
            guard.Wait();
            //......
         }
    }

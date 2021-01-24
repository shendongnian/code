    private void AddItems()
    {
        for (Int64 i = 100000; i < 30000; i++)
        {
            concurrentQueue.Enqueue(i.ToString());
            this.Invoke(new MethodInvoker(delegate()
            {
                label1.Text = i.ToString();
                label1.Update();
            }));
            if (i < 100004)
                Thread.Sleep(1000);
        }
    }

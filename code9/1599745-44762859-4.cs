    private void AddItems()
    {
        for (Int64 i = 100000; i < 300000; i++)
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
    
    private void Kick()
    {
        while (bKeepRunning)
        {
            int recordCountNew = concurrentQueue.Count();
            if (recordCountNew != 0)
            {
                RemoveItems();
            }
        }
    } 
    
    private void Reconnect()
    {
        currentSeqNo = "";
        previousSeqNo = "-1";
        bKeepRunning = false;
        threadTask = null;
    
        string someItem;
        while (concurrentQueue.Count > 0)
        {
    	concurrentQueue.TryDequeue(out someItem);
        }
    
        this.Invoke(new MethodInvoker(delegate()
        {
    	label1.Text = "";
    	label2.Text = "";
    
    	label1.Update();
    	label2.Update();
        }));
        Thread.Sleep(2000);
    
        AddItems();
    
        bKeepRunning = true;
    
    
        if (threadTask == null)
        {
    	threadTask = new Thread(Kick);
    	threadTask.Start();
        }
    }

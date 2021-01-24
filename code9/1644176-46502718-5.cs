        private void ProcessData(CancellationToken token)
        {
        	while(!token.IsCancellationRequested)
        	{                
        		// do work
            }
        }
     And call it with this:
        Task processingTask;
        CancellationTokenSource cts;
        void StartProcessing()
        {
            cts = new CancellationTokenSource();
            processingTask = Task.Run(() => ProcessData(cts.Token), cts.Token);
        }
    
        btnExit.Click += async (senders, args) =>
        {
            cts.Cancel();
            try
            {
                await processingTask;
            }
            finally
            {
                FormMain.Close();
            }                
        }

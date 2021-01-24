    public async Task SubscribeToReport(CancellationToken token)
    {
        Console.WriteLine("Waiting for task to finish or cancel...");
        await Task.Run(runReportTask(token), token);
        Console.WriteLine("Task has finished or was canceled.");
    }
    private Task runReportTask(CancellationToken token)
    {
        bool moreToDo = false;
        token.ThrowIfCancellationRequested();
        while(moreToDo && !Toke.IsCancellatinRequested)
        {
            // Do important code here, 
            // if this takes some time, make sure that 
            // you reqularly check IsCancellationRequested
            // this part runs until!moreToDo
         }
         if (token.IsCancellationRequested)
         {
             Console.WriteLine("Task canceled."); 
             // do cleanup here
         }
    }

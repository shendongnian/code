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
            // this may not take long, or reqularly check IsCancellationRequested
            // this might aldo change moreToDo
         }
         if (token.IsCancellationRequested)
         {
             Console.WriteLine("Task canceled."); 
             // do cleanup here
         }
    }

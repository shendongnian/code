    public void MainThread()
    {
        Task workB = WorkB();
        ChildThread(workB); // you don't need to use Task.Run here, the task is ran automatically
        WorkA();
        WorkC();
    }
    
    public async Task ChildThread(Task otherTaskToWait)
    {
        WorkD();
        await otherTaskToWait;
        Need_WorkB_ToBeCompletedBeforeThisOne();
    }

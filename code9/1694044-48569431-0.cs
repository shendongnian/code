    public Task StartAction() {
        var mainTask = Task.Factory.StartNew(InternalAction);
        var continuation = mainTask.ContinueWith(_ => { IsFinished = true; });
        MainTask = continuation;
        return mainTask;
    }  

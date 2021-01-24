    public void RunConcurrentTasks()
    {
        DoSomethingAsync().Result;
        DoSomethingElseAsync().Result;
    }

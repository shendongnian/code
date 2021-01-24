    public void ProcessSomeWork(SomeWork work)
    {
        if(work.IsCompleted)
        {
            return;
        }
        work.DoSomething();
        DoSomethingElseToWork(work);
    }

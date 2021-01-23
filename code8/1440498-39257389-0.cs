    void DoSomething(Func<IStatistic<string>> factory)
    {
        string[] inputData = ...
        foreach (string line in factory().Calculate(inputData))
        {
            // do something...
        }
    }

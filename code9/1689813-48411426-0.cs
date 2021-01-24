    var simulationResults = new ConcurrentBag<double>();
    Parallel.For(0, 1000, (i, loopState) =>
    {
        progressAction?.Invoke();
        double aResult = someMethod()
        if (double.IsNaN(aResult))
        {
            //or loopState.Break();
            loopState.Stop();
        }
        simulationResults.Add(aResult);
    });

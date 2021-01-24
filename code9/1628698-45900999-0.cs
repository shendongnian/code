    public void RunIterations()
    {
        var iterations = new List<Iteration>();
    
        // Adding items that represent the iterations to run
        // Here we're creating an array of tasks for each iteration
        // The running RunIteration for each iteration that needs to be created
        // However, the tasks will never finish unless the cancellation is requested (as we can see in RunIteration method).
        var iterationTasks = new Task[iterations.Count];
        var iterationIndex = 0;
        foreach (SqlEchoIteration iteration in iterations)
        {
            iterationTasks[iterationIndex] = RunIteration(iteration);
            iterationIndex++;
        }
        Task.WaitAll(iterationTasks);
    }
    private async Task RunIteration(Iteration iteration)
    {
            // We're creating an endless loop that will keep starting the RunAsync() for the iteration until the cancellation is requested.
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                // We're running the RunAsync() without waiting for it to finish.
                // It's done on purpose: in case any stages in the iteration take more time than expected
                // then another iteration is started in parallel as the previous one is finishing.
                iteration.RunAsync().ContinueWith(
                    task => {
                        DoSomethingWithResult(task.Result);
                    });
                // Waiting for the duration of the iteration to start the next one.
                await Task.Delay(( new TimeSpan().FromSeconds(60));
            }
    }

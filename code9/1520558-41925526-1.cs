    var workerTask = restService.GetRequestAsync(articleAdr, articleParams);
    var cancellationTask = Task.Delay(1000, cts.Token);
    
    await Task.WhenAny(workerTask, cancellationTask);
    if (workerTask.Status == TaskStatus.RanToCompletion)
    {
      // Note that this is NOT a blocking call because the Task ran to completion.
      var response = workerTask.Result;
    
      // Do whatever work with the completed result.
    }
    else
    {
      // Handle the cancellation.
      // NOTE: You do NOT want to call workerTask.Result here. It will be a blocking call and will block until 
      // your previous method completes, especially since you aren't passing the CancellationToken.
    }

     try
     {
        receiverTask.Wait();
        if (receiverTask.Status == TaskStatus.RanToCompletion)
           Console.WriteLine("Completed: {0}  Result: {1}", receiverTask.GetAwaiter().IsCompleted, receiverTask.Result);
     }
     catch (Exception)
     {
        receiverTask.ContinueWith(t =>
        {
           //With continuation
           if (receiverTask.IsFaulted == true)
              Console.WriteLine(receiverTask.Exception.InnerExceptions[0].Message);
        }, TaskContinuationOptions.OnlyOnFaulted);
           //or without
           //if (receiverTask.IsCanceled == true)
           //Console.WriteLine(receiverTask.Exception.InnerExceptions[0].Message);
     }

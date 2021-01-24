     receiverTask.ContinueWith(t =>
     {
        //Continue on faulted
        Console.WriteLine(receiverTask.GetAwaiter().IsCompleted);
        if (receiverTask.IsFaulted == true)
           Console.WriteLine(receiverTask.Exception.InnerExceptions[0].Message);
     }, TaskContinuationOptions.OnlyOnFaulted).Wait(0);
     receiverTask.ContinueWith(t =>
     {
        //Continue on canceled
        Console.WriteLine(receiverTask.GetAwaiter().IsCompleted);
        if (receiverTask.IsCanceled == true)
           Console.WriteLine(receiverTask.Exception.InnerExceptions[0].Message);
     }, TaskContinuationOptions.OnlyOnCanceled).Wait(0);
     receiverTask.ContinueWith(t =>
     {
        //Standard behaviour
        Console.WriteLine(receiverTask.GetAwaiter().IsCompleted);
        Console.WriteLine(receiverTask.Status.ToString());
     }, TaskContinuationOptions.None).Wait();
     //This writes only if no errors have been raised
     if (receiverTask.Status == TaskStatus.RanToCompletion)
        Console.WriteLine("Completed: {0}  Result: {1}", receiverTask.GetAwaiter().IsCompleted, receiverTask.Result);

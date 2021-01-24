    var parentTask = Task.Factory.StartNew(() =>
    {
        Task.Factory.StartNew(() => Thread.Sleep(1000), TaskCreationOptions.AttachedToParent)
        .ContinueWith(antecedent => Console.WriteLine("parent task completed", TaskContinuationOptions.AttachedToParent);
    });

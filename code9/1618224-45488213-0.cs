    // Define the source observable.
    var obs = ReadDatabase().SubscribeOn(NewThreadScheduler.Default);
    // Create our queue which calls Send for each observable item.
    var queue = new ActionBlock<string>(data => _connection.Send(data));
    try
    {
      // Subscribe the queue to the observable and (asynchronously) wait for it to complete.
      using (var subscription = obs.Subscribe(queue.AsObserver()))
        await queue.Completion;
    }
    catch (Exception ex)
    {
      // The first exception thrown from Send will end up here.
      Console.WriteLine(ex.Message);
    }

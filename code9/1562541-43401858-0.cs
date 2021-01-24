    // no more simultaneous tasks than processors available
    var dataItems = new BlockingCollection<IList<Data>>(Environment.ProcessorCount);
    // if your processing is long enough, consider notifying the scheduler about it
    // Task.Factory.StartNew(() => { }, CancellationToken,
    //   TaskCreationOptions.LongRunning, TaskScheduler.Default);
    Task.Run(() =>
    {
        while (!dataItems.IsCompleted)
        {
            IList<Data> data = null;
            try
            {
                data = dataItems.Take();
            }
            catch (InvalidOperationException) { /* completion called */ }
            if (data != null)
            {
                // service call for a taken data
                myService.MakeDBCalls(data);
            }
        }
    });
    foreach (var collection in groupedCollections)
    {
        // Blocks if dataItems.Count == dataItems.BoundedCapacity
        dataItems.Add(collection.ToList());
    }
    // Let consumer know we are done.
    dataItems.CompleteAdding();

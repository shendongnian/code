    var actionBlock = new ActionBlock<int>(async index =>
    {
        await CallRequestsAsync(data1, data2);
    }, new ExecutionDataflowBlockOptions
    {
        MaxDegreeOfParallelism = 30,
        BoundedCapacity = 100,
    });
    for (int i=0; i <= maxsize; i++)
    {
        actionBlock.Post(i); // or await actionBlock.SendAsync(i) if calling method is also async
    }
    actionBlock.Complete();
    actionBlock.Completion.Wait(); // or await actionBlock.Completion if calling method is also async

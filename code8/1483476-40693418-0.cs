    var producerCollection = new BlockingCollection<Message>();
    var consumerCollection = new BlockingCollection<Results>();
    var combinedCollection = new BlockingCollection<object>();
    var producerCombiner = Task.Run(() =>
    {
        foreach (var item in producerCollection.GetConsumingEnumerable())
        {
            combinedCollection.Add(item);
        }
    });
    var consumerCombiner = Task.Run(() =>
    {
        foreach (var item in consumerCollection.GetConsumingEnumerable())
        {
            combinedCollection.Add(item);
        }
    });
    Task.WhenAll(producerCombiner, consumerCombiner)
        .ContinueWith(_ => combinedCollection.CompleteAdding());
    foreach (var item in combinedCollection.GetConsumingEnumerable())
    {
        // process item here
    }

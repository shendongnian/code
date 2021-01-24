    while(continueProcessingCollection)
    {
        if(blockingCollection.TryTake(out value, TimeSpan.FromSeconds(myTimeout)))
        {
            // process value, decide to toggle continueProcessingCollection
        }
    }

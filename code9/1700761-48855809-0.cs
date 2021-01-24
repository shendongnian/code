    //Option A, common one, loop doesn't need to have iteration at all
    Task.Factory.StartNew(() =>
    {				
        while (shouldLooping)
        {
            //do your job
        }
    });
    
    //Option B, kind of wierd, loop will have at least one iteration
    Task.Factory.StartNew(() =>
    {				
        do
        {
            //do your job
        } while (shouldLooping);
    });
    
    //Option C, if you are driven by producer/consumer pattern, BlockingCollection should be shared between producer and consumer
    Task.Factory.StartNew(() =>
    {
        foreach (var item in blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine(item);
        }
    });

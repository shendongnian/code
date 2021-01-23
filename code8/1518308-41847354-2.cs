    List<Func<int, Task>> observers = new List<Func<int, Task>>
    {
          n => Console.WriteLine(n),
          n => Console.WriteLine(n * i),
          n => Console.WriteLine(n * n / i)
    };
    // Create an ActionBlock<int> object that prints values
    // to the console.
    var actionBlock = new ActionBlock<int>
    (
        n => 
        {
             // Fire and forget call to all observers
             foreach(Func<int, Task> observer in observers)
             {
                  // Don't await for its completion
                  observer(n);
             }         
        }
    );
    
    // Post several messages to the block.
    for (int i = 0; i < 3; i++)
    {
       actionBlock.Post(i * 10);
    }
    
    // Set the block to the completed state
    actionBlock.Complete();
    
    // See how I commented out the following sentence.
    // You don't wait actions to complete as you want the fire
    // and forget behavior!
    // actionBlock.Completion.Wait();

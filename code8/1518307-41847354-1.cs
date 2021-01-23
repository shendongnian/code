    // Create an ActionBlock<int> object that prints values
    // to the console.
    var actionBlock = new ActionBlock<int>
    (
        n => 
        {
             // Asynchronous stuff here             
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

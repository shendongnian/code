    using(var parentContext = LoggingContext("Method 1"))
    {
        Task.WaitAll(
           new Task(() => {
              using(parentContext.Clone()) 
              {
                  Method("Method A", "A");
              }
           }), 
           ...
    }

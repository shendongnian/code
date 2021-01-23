    try
    {
        Test.Handler(bus => new Processor() { Bus = bus }).OnMessage<ISomeHappenedEvent>();
    }
    catch (TargetInvocationException ex)
    {
        // Asserts against ex.InnerException
        ...
    }

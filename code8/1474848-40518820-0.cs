    [Test]
    public void it_should_publish_event()
    {
        Test.Handler(bus => new Processor() { Bus = bus, DoNotThrow = true })
            .ExpectPublish<IFailedEvent>()
            .OnMessage<ISomeHappenedEvent>();
    }
    
    [Test, ExpectedException(typeof(YourException))]
    public void it_should_throw()
    {
        Test.Handler(bus => new Processor() { Bus = bus })
            .OnMessage<ISomeHappenedEvent>();
    }

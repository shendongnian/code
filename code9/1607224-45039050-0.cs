    public void Test()
    {
        var fixture = new Fixture();
    
        fixture.Inject<IBeta>(new Beta("test"));
        IAlpha alpha = fixture.Create<Alpha>();
    }

    [TestInitialize]
    public void TestSetup()
    {
        this.notifyCount = 0;
        this.simpleNotify = new SimpleNotify();
        this.simpleNotify.PropertyChanged += SimpleNotify_PropertyChanged;
        this.simpleNotify.Monitor(); //New API for Montioring
    
        Thread thread = new Thread(this.bumpCount)
        {
            IsBackground = true,
            Name = @"My Background Thread",
            Priority = ThreadPriority.Normal
        };
        thread.Start();
    }
    
    [TestMethod]
    public async Task TestMethod1()
    {
        await Task.Delay(100);
        this.notifyCount.Should().Be(1);
        this.simpleNotify.Montior().Should().RaisePropertyChangeFor(x => x.Count); // New API for Monitoring
    }

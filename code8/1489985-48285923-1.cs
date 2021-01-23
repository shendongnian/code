    [TestInitialize]
    public void TestSetup()
    {
        this.notifyCount = 0;
        this.simpleNotify = new SimpleNotify();
        this.simpleNotify.PropertyChanged += SimpleNotify_PropertyChanged;
    
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
        using (var MonitoredSimpleNotify = this.simpleNotify.Monitor())
        {
            await Task.Delay(100);
            this.notifyCount.Should().Be(1);
            MonitoredSimpleNotify.Should().RaisePropertyChangeFor(x => x.Count); // New API for Monitoring
        }
    }

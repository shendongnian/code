    private ILog Log;
    [OneTimeSetUp]    
    public void OneTimeSetUp() 
    {
        Log = LogManager.GetLogger(GetType()); 
    }
    [Test]
    public void LogTest()
    {
        Log.Info("test test test test");
    }

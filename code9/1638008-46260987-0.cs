    [SetUpFixture]
    public class TestsSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Log.Logger = new LoggerConfiguration().Enrich.WithExceptionDetails()
                                                  .WriteTo.Seq("http://localhost:5341")
                                                  .MinimumLevel.Verbose()
                                                  .CreateLogger();
        }
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Log.CloseAndFlush();
        }
    }

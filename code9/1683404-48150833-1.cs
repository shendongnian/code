    public static class TestHelpers
    {
        private static TestServer _testServer;
        private static readonly object _initializationLock = new object();
        public static TestServer GetTestServer()
        {
            if (_testServer == null)
            {
                InitializeTestServer();
            }
            return _testServer;
        }
        private static void InitializeTestServer()
        {
            lock (_initializationLock)
            {
                if (_testServer != null)
                {
                    return;
                }
                var webHostBuilder = new WebHostBuilder()
                    .UseStartup<IntegrationTestsStartup>();
                var testServer = new TestServer(webHostBuilder);
                var initializationTask = InitializeDatabase(testServer);
                initializationTask.ConfigureAwait(false);
                initializationTask.Wait();
                testServer.BaseAddress = new Uri("http://localhost");
                _testServer = testServer;
            }
        }
    }

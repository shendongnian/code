    _server = new TestServer(new WebHostBuilder()
        .UseEnvironment("Development")
        .UseStartup<TestStartup>());
    class TestStartup
    {
        public TestStartup (IHostingEnvironment env)
        {
          ...
        }
    }

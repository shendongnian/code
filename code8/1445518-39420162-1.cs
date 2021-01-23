    public sealed class TestMiddleware
    {
        private readonly ITestService _testService;
        public TestMiddleware(ITestService testService)
        {
            _testService = testService;
        }
        public async Task Invoke(IOwinContext context, Func<Task> next)
        {
            var test = _testService.DoSomething();
            await next();
        }
    }

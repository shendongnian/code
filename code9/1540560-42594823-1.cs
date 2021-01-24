    public class TestResult
    {
        public Exception Exception { get; set; }
        public object Data { get; set; }
    }
    
    public class TestActionResult : IActionResult
    {
        private readonly TestResult _result;
    
        public TestActionResult(TestResult result)
        {
            _result = result;
        }
    
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Data)
            {
                StatusCode = _result.Exception != null
                    ? StatusCodes.Status500InternalServerError
                    : StatusCodes.Status200OK
            };
    
            await objectResult.ExecuteResultAsync(context);
        }
    }

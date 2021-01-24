    public class TestActionResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
    
            response.StatusCode = StatusCodes.Status200OK;
            await response.WriteAsync("Test result");
        }
    }

    public class MyThinController : Controller
    {
        [
            HttpGet,
            Route("api/[controller]/foos/{bar}"),
            Authorize(Policy = nameof(Policies.StackoverflowOp))
        ]
        public Task<IActionResult> GetFoo([FromRoute] Bar bar,
                                          [FromServices] IExampleService service)
            => service.GetAsync(bar);
    }

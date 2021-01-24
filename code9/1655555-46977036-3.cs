    // force all actions in the controller
    [Produces("text/csv")]
    public class FooController
    {
        // or apply on to a single action
        [Produces("text/csv")]
        public async Task<IActionResult> Index()
        {
        }
    }

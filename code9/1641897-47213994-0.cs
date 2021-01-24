    public class FooModel : PageModel
    {
        public void OnGet()
        {
            Trace.TraceInformation("Returns the page");
        }
        public IActionResult OnGetTest()
        {
            return new OkObjectResult( "Test" );
        }
    }

    public class ApiController : Controller
    {
        protected OmbiContext ctx;
        public ApiController(OmbiContext dbctx)
        {
            ctx = dbctx;
        }
        public async Task<IActionResult> yourAsyncAction()
        {
            // access ctx here
        }
    }

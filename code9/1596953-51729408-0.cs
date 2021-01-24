    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            NewException();
            return Ok("<h1>Hi, Welcome！</h1>");
        }
        private async void NewException()
        {
            throw new InvalidOperationException("WTF");
        }

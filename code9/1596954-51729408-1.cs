    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await NewException();
            return Ok("<h1>Hi, Welcome！</h1>");
        }
        private async Task NewException()
        {
            throw new InvalidOperationException("WTF");
        }

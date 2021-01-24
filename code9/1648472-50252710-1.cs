    [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Worked");
        }
    }

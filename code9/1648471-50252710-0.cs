    [Authorize(AuthenticationSchemes = AuthSchemes)]
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        private const string AuthSchemes =
            CookieAuthenticationDefaults.AuthenticationScheme + "," +
            JwtBearerDefaults.AuthenticationScheme;
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Worked");
        }
    }

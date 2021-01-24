    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]  
    public class SomeControlelr: Controller{
        [HttpGet("", Name = "Someaction"), MapToApiVersion("1.0")]
        public async Task<IActionResult> SomeAction(string someParameter)

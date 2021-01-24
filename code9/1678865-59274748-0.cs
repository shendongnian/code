    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProducesResponseFormatController : ControllerBase {
        [HttpGet]
        [Produces("application/xml")]
        public IActionResult Get() {
            // this worked well
            return Ok(new Model.appsettings.TokenSettings()); 
            // this didn't
            return Ok(new { A = new { B = "b inside a", C = "C inside A" }, D = "E" }); 
        }
    }

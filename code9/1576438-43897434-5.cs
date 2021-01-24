    [Route("api/[controller]")]
    public class ValuesController : Controller {
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery]QueryParameters parameters) {    
            if(ModelState.IsValid) {
                return Ok(new [] { parameters.A.ToString(), parameters.B.ToString() });
            }
            return BadRequest();
        }        
    }
